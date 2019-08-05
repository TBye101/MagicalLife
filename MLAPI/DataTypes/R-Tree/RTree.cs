//   RTree.java
//   Java Spatial Index Library
//   Copyright (C) 2002 Infomatiq Limited
//   Copyright (C) 2008 Aled Morris aled@sourceforge.net
//
//  This library is free software; you can redistribute it and/or
//  modify it under the terms of the GNU Lesser General Public
//  License as published by the Free Software Foundation; either
//  version 2.1 of the License, or (at your option) any later version.
//
//  This library is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//  Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

//  Ported to C# By Dror Gluska, April 9th, 2009

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace MLAPI.DataTypes
{
    /// <summary>
    /// <para>
    /// This is a lightweight RTree implementation, specifically designed
    /// for the following features (in order of importance):
    /// </para>
    /// <para>
    /// Fast intersection query performance. To achieve this, the RTree
    /// uses only main memory to store entries. Obviously this will only improve
    /// performance if there is enough physical memory to avoid paging.
    /// Low memory requirements.
    /// Fast add performance.
    /// </para>
    /// <para>
    /// The main reason for the high speed of this RTree implementation is the
    /// avoidance of the creation of unnecessary objects, mainly achieved by using
    /// primitive collections from the trove4j library.
    /// author aled@sourceforge.net
    /// version 1.0b2p1
    /// Ported to C# By Dror Gluska, April 9th, 2009
    /// </para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RTree<T>
    {
        private const int LOCKING_TIMEOUT = 10000;

        private readonly ReaderWriterLock Locker = new ReaderWriterLock();
        private const string VERSION = "1.0b2p2";

        // parameters of the tree
        private const int DEFAULT_MAX_NODE_ENTRIES = 10;

        internal int MaxNodeEntries;
        private int MinNodeEntries;

        // map of nodeId -&gt; Node&lt;T&gt; object
        // [x] TODO eliminate this map - it should not be needed. Nodes
        // can be found by traversing the tree.
        //private TIntObjectHashMap nodeMap = new TIntObjectHashMap();
        private readonly Dictionary<int, Node<T>> NodeMap = new Dictionary<int, Node<T>>();

        // internal consistency checking - set to true if debugging tree corruption
        public bool InternalConsistencyChecking = false;

        // used to mark the status of entries during a Node&lt;T&gt; split
        private const int ENTRY_STATUS_ASSIGNED = 0;

        private const int ENTRY_STATUS_UNASSIGNED = 1;
        private byte[] EntryStatus = null;
        private byte[] InitialEntryStatus = null;

        // stacks used to store nodeId and entry index of each Node&lt;T&gt;
        // from the root down to the leaf. Enables fast lookup
        // of nodes when a split is propagated up the tree.
        //private TIntStack parents = new TIntStack();
        private readonly Stack<int> Parents = new Stack<int>();

        //private TIntStack parentsEntry = new TIntStack();
        private readonly Stack<int> ParentsEntry = new Stack<int>();

        // initialization
        private int TreeHeight = 1; // leaves are always level 1

        private int RootNodeId = 0;
        private int Msize = 0;

        // Enables creation of new nodes
        //private int highestUsedNodeId = rootNodeId;
        private int HighestUsedNodeId = 0;

        // Deleted Node&lt;T&gt; objects are retained in the nodeMap,
        // so that they can be reused. Store the IDs of nodes
        // which can be reused.
        //private TIntStack deletedNodeIds = new TIntStack();
        private readonly Stack<int> DeletedNodeIds = new Stack<int>();

        // List of nearest rectangles. Use a member variable to
        // avoid recreating the object each time nearest() is called.
        //private TIntArrayList nearestIds = new TIntArrayList();
        //List<int> nearestIds = new List<int>();

        //Added dictionaries to support generic objects..
        //possibility to change the code to support objects without dictionaries.
        private readonly Dictionary<int, T> IdsToItems = new Dictionary<int, T>();

        private readonly Dictionary<T, int> ItemsToIds = new Dictionary<T, int>();
        private volatile int Idcounter = int.MinValue;

        /// <summary>
        /// Initialize implementation dependent properties of the RTree.
        /// </summary>
        public RTree()
        {
            this.Init();
        }

        /// <summary>
        /// Initialize implementation dependent properties of the RTree.
        /// </summary>
        /// <param name="maxNodeEntries">his specifies the maximum number of entries
        ///in a node. The default value is 10, which is used if the property is
        ///not specified, or is less than 2.</param>
        /// <param name="minNodeEntries">This specifies the minimum number of entries
        ///in a node. The default value is half of the MaxNodeEntries value (rounded
        ///down), which is used if the property is not specified or is less than 1.
        ///</param>
        public RTree(int maxNodeEntries, int minNodeEntries)
        {
            this.MinNodeEntries = minNodeEntries;
            this.MaxNodeEntries = maxNodeEntries;
            this.Init();
        }

        private void Init()
        {
            this.Locker.AcquireWriterLock(LOCKING_TIMEOUT);
            // Obviously a Node&lt;T&gt; with less than 2 entries cannot be split.
            // The Node&lt;T&gt; splitting algorithm will work with only 2 entries
            // per node, but will be inefficient.
            if (this.MaxNodeEntries < 2)
            {
                Debug.WriteLine($"Invalid MaxNodeEntries = {this.MaxNodeEntries} Resetting to default value of {DEFAULT_MAX_NODE_ENTRIES}");
                this.MaxNodeEntries = DEFAULT_MAX_NODE_ENTRIES;
            }

            // The MinNodeEntries must be less than or equal to (int) (MaxNodeEntries / 2)
            if (this.MinNodeEntries < 1 || this.MinNodeEntries > this.MaxNodeEntries / 2)
            {
                Debug.WriteLine("MinNodeEntries must be between 1 and MaxNodeEntries / 2");
                this.MinNodeEntries = this.MaxNodeEntries / 2;
            }

            this.EntryStatus = new byte[this.MaxNodeEntries];
            this.InitialEntryStatus = new byte[this.MaxNodeEntries];

            for (int i = 0; i < this.MaxNodeEntries; i++)
            {
                this.InitialEntryStatus[i] = ENTRY_STATUS_UNASSIGNED;
            }

            Node<T> root = new Node<T>(this.RootNodeId, 1, this.MaxNodeEntries);
            this.NodeMap.Add(this.RootNodeId, root);

            Debug.WriteLine($"init()  MaxNodeEntries = {this.MaxNodeEntries}, MinNodeEntries = {this.MinNodeEntries}");
            this.Locker.ReleaseWriterLock();
        }

        /// <summary>
        /// Adds an item to the spatial index
        /// </summary>
        /// <param name="r"></param>
        /// <param name="item"></param>
        public void Add(Rectangle r, T item)
        {
            this.Locker.AcquireWriterLock(LOCKING_TIMEOUT);
            this.Idcounter++;
            int id = this.Idcounter;

            this.IdsToItems.Add(id, item);
            this.ItemsToIds.Add(item, id);

            this.Add(r, id);
            this.Locker.ReleaseWriterLock();
        }

        private void Add(Rectangle r, int id)
        {
            Debug.WriteLine($"Adding rectangle {r}, id {id}");

            this.Add(r.Copy(), id, 1);

            this.Msize++;
        }

        /// <summary>
        /// Adds a new entry at a specified level in the tree
        /// </summary>
        /// <param name="r"></param>
        /// <param name="id"></param>
        /// <param name="level"></param>
        private void Add(Rectangle r, int id, int level)
        {
            // I1 [Find position for new record] Invoke ChooseLeaf to select a
            // leaf Node&lt;T&gt; L in which to place r
            Node<T> n = this.ChooseNode(r, level);
            Node<T> newLeaf = null;

            // I2 [Add record to leaf node] If L has room for another entry,
            // install E. Otherwise invoke SplitNode to obtain L and LL containing
            // E and all the old entries of L
            if (n.EntryCount < this.MaxNodeEntries)
            {
                n.AddEntryNoCopy(r, id);
            }
            else
            {
                newLeaf = this.SplitNode(n, r, id);
            }

            // I3 [Propagate changes upwards] Invoke AdjustTree on L, also passing LL
            // if a split was performed
            Node<T> newNode = this.AdjustTree(n, newLeaf);

            // I4 [Grow tree taller] If Node&lt;T&gt; split propagation caused the root to
            // split, create a new root whose children are the two resulting nodes.
            if (newNode != null)
            {
                int oldRootNodeId = this.RootNodeId;
                Node<T> oldRoot = this.GetNode(oldRootNodeId);

                this.RootNodeId = this.GetNextNodeId();
                this.TreeHeight++;
                Node<T> root = new Node<T>(this.RootNodeId, this.TreeHeight, this.MaxNodeEntries);
                root.AddEntry(newNode.Mbr, newNode.NodeId);
                root.AddEntry(oldRoot.Mbr, oldRoot.NodeId);
                this.NodeMap.Add(this.RootNodeId, root);
            }

            if (this.InternalConsistencyChecking)
            {
                this.CheckConsistency(this.RootNodeId, this.TreeHeight, null);
            }
        }

        /// <summary>
        /// Deletes an item from the spatial index
        /// </summary>
        /// <param name="r"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Delete(Rectangle r, T item)
        {
            this.Locker.AcquireWriterLock(LOCKING_TIMEOUT);
            int id = this.ItemsToIds[item];

            bool success = this.Delete(r, id);
            if (success)
            {
                this.IdsToItems.Remove(id);
                this.ItemsToIds.Remove(item);
            }
            this.Locker.ReleaseWriterLock();
            return success;
        }

        private bool Delete(Rectangle r, int id)
        {
            // FindLeaf algorithm in-lined here. Note the "official" algorithm
            // searches all overlapping entries. This seems inefficient to me,
            // as an entry is only worth searching if it contains (NOT overlaps)
            // the rectangle we are searching for.
            //
            // Also the algorithm has been changed so that it is not recursive.

            // FL1 [Search subtrees] If root is not a leaf, check each entry
            // to determine if it contains r. For each entry found, invoke
            // findLeaf on the Node&lt;T&gt; pointed to by the entry, until r is found or
            // all entries have been checked.
            this.Parents.Clear();
            this.Parents.Push(this.RootNodeId);

            this.ParentsEntry.Clear();
            this.ParentsEntry.Push(-1);
            Node<T> n = null;
            int foundIndex = -1;  // index of entry to be deleted in leaf

            while (foundIndex == -1 && this.Parents.Count > 0)
            {
                n = this.GetNode(this.Parents.Peek());
                int startIndex = this.ParentsEntry.Peek() + 1;

                if (!n.IsLeaf())
                {
                    Debug.WriteLine($"searching Node<T> {n.NodeId}, from index {startIndex}");
                    bool contains = false;
                    for (int i = startIndex; i < n.EntryCount; i++)
                    {
                        if (n.Entries[i].Contains(r))
                        {
                            this.Parents.Push(n.Ids[i]);
                            this.ParentsEntry.Pop();
                            this.ParentsEntry.Push(i); // this becomes the start index when the child has been searched
                            this.ParentsEntry.Push(-1);
                            contains = true;
                            break; // IE go to next iteration of while()
                        }
                    }
                    if (contains)
                    {
                        continue;
                    }
                }
                else
                {
                    foundIndex = n.FindEntry(r, id);
                }

                this.Parents.Pop();
                this.ParentsEntry.Pop();
            } // while not found

            if (foundIndex != -1)
            {
                n?.DeleteEntry(foundIndex, this.MinNodeEntries);
                this.CondenseTree(n);
                this.Msize--;
            }

            // shrink the tree if possible (i.e. if root Node&lt;T%gt; has exactly one entry,and that
            // entry is not a leaf node, delete the root (it's entry becomes the new root)
            Node<T> root = this.GetNode(this.RootNodeId);
            while (root.EntryCount == 1 && this.TreeHeight > 1)
            {
                root.EntryCount = 0;
                this.RootNodeId = root.Ids[0];
                this.TreeHeight--;
                root = this.GetNode(this.RootNodeId);
            }

            return foundIndex != -1;
        }

        /// <summary>
        /// Retrieve nearest items to a point in radius furthestDistance
        /// </summary>
        /// <param name="p">Point of origin</param>
        /// <param name="furthestDistance">maximum distance</param>
        /// <returns>List of items</returns>
        public List<T> Nearest(Point p, float furthestDistance)
        {
            List<T> retval = new List<T>();
            this.Locker.AcquireReaderLock(LOCKING_TIMEOUT);
            this.Nearest(p, (int id) =>
           {
               retval.Add(this.IdsToItems[id]);
           }, furthestDistance);
            this.Locker.ReleaseReaderLock();
            return retval;
        }

        private void Nearest(Point p, Action<int> v, float furthestDistance)
        {
            Node<T> rootNode = this.GetNode(this.RootNodeId);

            List<int> nearestIds = new List<int>();

            this.Nearest(p, rootNode, nearestIds, furthestDistance);

            foreach (int id in nearestIds)
            {
                v(id);
            }

            nearestIds.Clear();
        }

        /// <summary>
        /// Retrieve items which intersect with Rectangle r
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public List<T> Intersects(Rectangle r)
        {
            List<T> retval = new List<T>();
            this.Locker.AcquireReaderLock(LOCKING_TIMEOUT);
            this.Intersects(r, (id) => retval.Add(this.IdsToItems[id]));
            this.Locker.ReleaseReaderLock();
            return retval;
        }

        private void Intersects(Rectangle r, Action<int> v)
        {
            Node<T> rootNode = this.GetNode(this.RootNodeId);
            this.Intersects(r, v, rootNode);
        }

        /// <summary>
        /// find all rectangles in the tree that are contained by the passed rectangle
        /// written to be non-recursive (should model other searches on this?)</summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public List<T> Contains(Rectangle r)
        {
            List<T> retval = new List<T>();
            this.Locker.AcquireReaderLock(LOCKING_TIMEOUT);
            this.Contains(r, (int id) =>
            {
                retval.Add(this.IdsToItems[id]);
            });

            this.Locker.ReleaseReaderLock();
            return retval;
        }

        private void Contains(Rectangle r, Action<int> v)
        {
            Stack<int> parents = new Stack<int>();
            //private TIntStack parentsEntry = new TIntStack();
            Stack<int> parentsEntry = new Stack<int>();

            // find all rectangles in the tree that are contained by the passed rectangle
            // written to be non-recursive (should model other searches on this?)

            parents.Push(this.RootNodeId);

            parentsEntry.Push(-1);

            // TODO: possible shortcut here - could test for intersection with the
            // MBR of the root node. If no intersection, return immediately.

            while (parents.Count > 0)
            {
                Node<T> n = this.GetNode(parents.Peek());
                int startIndex = parentsEntry.Peek() + 1;

                if (!n.IsLeaf())
                {
                    // go through every entry in the index Node<T> to check
                    // if it intersects the passed rectangle. If so, it
                    // could contain entries that are contained.
                    bool intersects = false;
                    for (int i = startIndex; i < n.EntryCount; i++)
                    {
                        if (r.Intersects(n.Entries[i]))
                        {
                            parents.Push(n.Ids[i]);
                            parentsEntry.Pop();
                            parentsEntry.Push(i); // this becomes the start index when the child has been searched
                            parentsEntry.Push(-1);
                            intersects = true;
                            break; // ie go to next iteration of while()
                        }
                    }
                    if (intersects)
                    {
                        continue;
                    }
                }
                else
                {
                    // go through every entry in the leaf to check if
                    // it is contained by the passed rectangle
                    for (int i = 0; i < n.EntryCount; i++)
                    {
                        if (r.Contains(n.Entries[i]))
                        {
                            v(n.Ids[i]);
                        }
                    }
                }
                parents.Pop();
                parentsEntry.Pop();
            }
        }

        /// <summary>
        /// Returns the bounds of all the entries in the spatial index, or null if there are no entries.
        /// </summary>
        public Rectangle GetBounds()
        {
            Rectangle bounds = null;

            this.Locker.AcquireReaderLock(LOCKING_TIMEOUT);
            Node<T> n = this.GetNode(this.GetRootNodeId());
            if (n?.GetMbr() != null)
            {
                bounds = n.GetMbr().Copy();
            }
            this.Locker.ReleaseReaderLock();
            return bounds;
        }

        /// <summary>
        /// Returns a string identifying the type of spatial index, and the version number
        /// </summary>
        public string GetVersion()
        {
            return "RTree-" + VERSION;
        }

        //-------------------------------------------------------------------------
        // end of SpatialIndex methods
        //-------------------------------------------------------------------------

        /// <summary>
        /// Get the next available Node&lt;T&gt; ID. Reuse deleted Node&lt;T&gt; IDs if
        /// possible
        /// </summary>
        private int GetNextNodeId()
        {
            if (this.DeletedNodeIds.Count > 0)
            {
                return this.DeletedNodeIds.Pop();
            }
            else
            {
                return 1 + this.HighestUsedNodeId++;
            }
        }

        /// <summary>
        /// Get a Node&lt;T&gt; object, given the ID of the node.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Node<T> GetNode(int index)
        {
            return this.NodeMap[index];
        }

        /// <summary>
        /// Get the root Node&lt;T&gt; ID
        /// </summary>
        /// <returns></returns>
        public int GetRootNodeId()
        {
            return this.RootNodeId;
        }

        /// <summary>
        /// Split a node. Algorithm is taken pretty much verbatim from
        /// Guttman's original paper.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="newRect"></param>
        /// <param name="newId"></param>
        /// <returns>return new Node&lt;T&gt; object.</returns>
        private Node<T> SplitNode(Node<T> n, Rectangle newRect, int newId)
        {
            // [Pick first entry for each group] Apply algorithm pickSeeds to
            // choose two entries to be the first elements of the groups. Assign
            // each to a group.

            // debug code
#if DEBUG
            float initialArea = 0;
            Rectangle union = n.Mbr.Union(newRect);
            initialArea = union.Area();
#endif

            Array.Copy(this.InitialEntryStatus, 0, this.EntryStatus, 0, this.MaxNodeEntries);

            Node<T> newNode = null;
            newNode = new Node<T>(this.GetNextNodeId(), n.Level, this.MaxNodeEntries);
            this.NodeMap.Add(newNode.NodeId, newNode);

            this.PickSeeds(n, newRect, newId, newNode); // this also sets the entryCount to 1

            // [Check if done] If all entries have been assigned, stop. If one
            // group has so few entries that all the rest must be assigned to it in
            // order for it to have the minimum number m, assign them and stop.
            while (n.EntryCount + newNode.EntryCount < this.MaxNodeEntries + 1)
            {
                if (this.MaxNodeEntries + 1 - newNode.EntryCount == this.MinNodeEntries)
                {
                    // assign all remaining entries to original node
                    for (int i = 0; i < this.MaxNodeEntries; i++)
                    {
                        if (this.EntryStatus[i] == ENTRY_STATUS_UNASSIGNED)
                        {
                            this.EntryStatus[i] = ENTRY_STATUS_ASSIGNED;
                            n.Mbr.Add(n.Entries[i]);
                            n.EntryCount++;
                        }
                    }
                    break;
                }
                if (this.MaxNodeEntries + 1 - n.EntryCount == this.MinNodeEntries)
                {
                    // assign all remaining entries to new node
                    for (int i = 0; i < this.MaxNodeEntries; i++)
                    {
                        if (this.EntryStatus[i] == ENTRY_STATUS_UNASSIGNED)
                        {
                            this.EntryStatus[i] = ENTRY_STATUS_ASSIGNED;
                            newNode.AddEntryNoCopy(n.Entries[i], n.Ids[i]);
                            n.Entries[i] = null;
                        }
                    }
                    break;
                }

                // [Select entry to assign] Invoke algorithm pickNext to choose the
                // next entry to assign. Add it to the group whose covering rectangle
                // will have to be enlarged least to accommodate it. Resolve ties
                // by adding the entry to the group with smaller area, then to the
                // the one with fewer entries, then to either. Repeat from S2
                this.PickNext(n, newNode);
            }

            n.Reorganize(this);

            // check that the MBR stored for each Node&lt;T&gt; is correct.
            if (this.InternalConsistencyChecking)
            {
                if (!n.Mbr.Equals(this.CalculateMbr(n)))
                {
                    Debug.WriteLine("Error: splitNode old Node<T> MBR wrong");
                }

                if (!newNode.Mbr.Equals(this.CalculateMbr(newNode)))
                {
                    Debug.WriteLine("Error: splitNode new Node<T> MBR wrong");
                }
            }

            // debug code
#if DEBUG
            float newArea = n.Mbr.Area() + newNode.Mbr.Area();
            float percentageIncrease = (100 * (newArea - initialArea)) / initialArea;
            Debug.WriteLine($"Node { n.NodeId} split. New area increased by {percentageIncrease}%");
#endif

            return newNode;
        }

        /// <summary>
        /// Pick the seeds used to split a node.
        /// Select two entries to be the first elements of the groups
        /// </summary>
        /// <param name="n"></param>
        /// <param name="newRect"></param>
        /// <param name="newId"></param>
        /// <param name="newNode"></param>
        private void PickSeeds(Node<T> n, Rectangle newRect, int newId, Node<T> newNode)
        {
            // Find extreme rectangles along all dimension. Along each dimension,
            // find the entry whose rectangle has the highest low side, and the one
            // with the lowest high side. Record the separation.
            float maxNormalizedSeparation = 0;
            int highestLowIndex = 0;
            int lowestHighIndex = 0;

            // for the purposes of picking seeds, take the MBR of the Node&lt;T&gt; to include
            // the new rectangle aswell.
            n.Mbr.Add(newRect);

            Debug.WriteLine($"pickSeeds(): NodeId = {n.NodeId}, newRect = {newRect}");

            for (int d = 0; d < Rectangle.Dimensions; d++)
            {
                float tempHighestLow = newRect.Min[d];
                int tempHighestLowIndex = -1; // -1 indicates the new rectangle is the seed

                float tempLowestHigh = newRect.Max[d];
                int tempLowestHighIndex = -1;

                for (int i = 0; i < n.EntryCount; i++)
                {
                    float tempLow = n.Entries[i].Min[d];
                    if (tempLow >= tempHighestLow)
                    {
                        tempHighestLow = tempLow;
                        tempHighestLowIndex = i;
                    }
                    else
                    {  // ensure that the same index cannot be both lowestHigh and highestLow
                        float tempHigh = n.Entries[i].Max[d];
                        if (tempHigh <= tempLowestHigh)
                        {
                            tempLowestHigh = tempHigh;
                            tempLowestHighIndex = i;
                        }
                    }

                    // PS2 [Adjust for shape of the rectangle cluster] Normalize the separations
                    // by dividing by the widths of the entire set along the corresponding
                    // dimension
                    float normalizedSeparation = (tempHighestLow - tempLowestHigh) / (n.Mbr.Max[d] - n.Mbr.Min[d]);

                    if (normalizedSeparation > 1 || normalizedSeparation < -1)
                    {
                        Debug.WriteLine("Invalid normalized separation");
                    }

                    Debug.WriteLine($"Entry {i}, dimension {d}: HighestLow = {tempHighestLow} (index {tempHighestLowIndex})" + ", LowestHigh = " +
                              tempLowestHigh + $" (index {tempLowestHighIndex}, NormalizedSeparation = {normalizedSeparation}");

                    // PS3 [Select the most extreme pair] Choose the pair with the greatest
                    // normalized separation along any dimension.
                    if (normalizedSeparation > maxNormalizedSeparation)
                    {
                        maxNormalizedSeparation = normalizedSeparation;
                        highestLowIndex = tempHighestLowIndex;
                        lowestHighIndex = tempLowestHighIndex;
                    }
                }
            }

            // highestLowIndex is the seed for the new node.
            if (highestLowIndex == -1)
            {
                newNode.AddEntry(newRect, newId);
            }
            else
            {
                newNode.AddEntryNoCopy(n.Entries[highestLowIndex], n.Ids[highestLowIndex]);
                n.Entries[highestLowIndex] = null;

                // move the new rectangle into the space vacated by the seed for the new node
                n.Entries[highestLowIndex] = newRect;
                n.Ids[highestLowIndex] = newId;
            }

            // lowestHighIndex is the seed for the original node.
            if (lowestHighIndex == -1)
            {
                lowestHighIndex = highestLowIndex;
            }

            this.EntryStatus[lowestHighIndex] = ENTRY_STATUS_ASSIGNED;
            n.EntryCount = 1;
            n.Mbr.Set(n.Entries[lowestHighIndex].Min, n.Entries[lowestHighIndex].Max);
        }

        /// <summary>
        /// Pick the next entry to be assigned to a group during a Node&lt;T&gt; split.
        /// [Determine cost of putting each entry in each group] For each
        /// entry not yet in a group, calculate the area increase required
        /// in the covering rectangles of each group
        /// </summary>
        /// <param name="n"></param>
        /// <param name="newNode"></param>
        /// <returns></returns>
        private void PickNext(Node<T> n, Node<T> newNode)
        {
            float maxDifference = float.NegativeInfinity;
            int next = 0;
            int nextGroup = 0;

            maxDifference = float.NegativeInfinity;

            Debug.WriteLine("pickNext()");

            for (int i = 0; i < this.MaxNodeEntries; i++)
            {
                if (this.EntryStatus[i] == ENTRY_STATUS_UNASSIGNED)
                {
                    if (n.Entries[i] == null)
                    {
                        Debug.WriteLine($"Error: Node<T> {n.NodeId}, entry {i} is null");
                    }

                    float nIncrease = n.Mbr.Enlargement(n.Entries[i]);
                    float newNodeIncrease = newNode.Mbr.Enlargement(n.Entries[i]);
                    float difference = Math.Abs(nIncrease - newNodeIncrease);

                    if (difference > maxDifference)
                    {
                        next = i;

                        if (nIncrease < newNodeIncrease)
                        {
                            nextGroup = 0;
                        }
                        else if (newNodeIncrease < nIncrease)
                        {
                            nextGroup = 1;
                        }
                        else if (n.Mbr.Area() < newNode.Mbr.Area())
                        {
                            nextGroup = 0;
                        }
                        else if (newNode.Mbr.Area() < n.Mbr.Area())
                        {
                            nextGroup = 1;
                        }
                        else if (newNode.EntryCount < this.MaxNodeEntries / 2)
                        {
                            nextGroup = 0;
                        }
                        else
                        {
                            nextGroup = 1;
                        }
                        maxDifference = difference;
                    }

                    Debug.WriteLine($"Entry {i} group0 increase = {nIncrease}, group1 increase = {newNodeIncrease}, diff = " +
                        difference + $", MaxDiff = {maxDifference} (entry {next})");
                }
            }

            this.EntryStatus[next] = ENTRY_STATUS_ASSIGNED;

            if (nextGroup == 0)
            {
                n.Mbr.Add(n.Entries[next]);
                n.EntryCount++;
            }
            else
            {
                // move to new node.
                newNode.AddEntryNoCopy(n.Entries[next], n.Ids[next]);
                n.Entries[next] = null;
            }
        }

        /// <summary>
        /// Recursively searches the tree for the nearest entry. Other queries
        /// call execute() on an IntProcedure when a matching entry is found;
        /// however nearest() must store the entry Ids as it searches the tree,
        /// in case a nearer entry is found.
        /// Uses the member variable nearestIds to store the nearest
        /// entry IDs.
        /// </summary>
        /// <remarks>TODO rewrite this to be non-recursive?</remarks>
        /// <param name="p"></param>
        /// <param name="n"></param>
        /// <param name="nearestDistance"></param>
        /// <returns></returns>
        private float Nearest(Point p, Node<T> n, List<int> nearestIds, float nearestDistance)
        {
            float distance = nearestDistance;
            for (int i = 0; i < n.EntryCount; i++)
            {
                float tempDistance = n.Entries[i].Distance(p);
                if (n.IsLeaf())
                { // for leaves, the distance is an actual nearest distance
                    if (tempDistance < nearestDistance)
                    {
                        distance = tempDistance;
                        nearestIds.Clear();
                    }
                    if (tempDistance <= nearestDistance)
                    {
                        nearestIds.Add(n.Ids[i]);
                    }
                }
                else
                { // for index nodes, only go into them if they potentially could have
                    // a rectangle nearer than actualNearest
                    if (tempDistance <= nearestDistance)
                    {
                        // search the child node
                        distance = this.Nearest(p, this.GetNode(n.Ids[i]), nearestIds, nearestDistance);
                    }
                }
            }
            return distance;
        }

        /// <summary>
        /// Recursively searches the tree for all intersecting entries.
        /// Immediately calls execute() on the passed IntProcedure when
        /// a matching entry is found.
        /// [x] TODO rewrite this to be non-recursive? Make sure it
        /// doesn't slow it down.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="v"></param>
        /// <param name="n"></param>
        private void Intersects(Rectangle r, Action<int> v, Node<T> n)
        {
            for (int i = 0; i < n.EntryCount; i++)
            {
                if (r.Intersects(n.Entries[i]))
                {
                    if (n.IsLeaf())
                    {
                        v(n.Ids[i]);
                    }
                    else
                    {
                        Node<T> childNode = this.GetNode(n.Ids[i]);
                        this.Intersects(r, v, childNode);
                    }
                }
            }
        }

        private Rectangle OldRectangle { get; } = new Rectangle(0, 0, 0, 0);

        /// <summary>
        /// Used by delete(). Ensures that all nodes from the passed node
        /// up to the root have the minimum number of entries.
        /// <para>
        /// Note that the parent and parentEntry stacks are expected to
        /// contain the nodeIds of all parents up to the root.
        /// </para>
        /// </summary>
        private void CondenseTree(Node<T> l)
        {
            // CT1 [Initialize] Set n=l. Set the list of eliminated
            // nodes to be empty.
            Node<T> n = l;
            Node<T> parent = null;
            int parentEntry = 0;

            //TIntStack eliminatedNodeIds = new TIntStack();
            Stack<int> eliminatedNodeIds = new Stack<int>();

            // CT2 [Find parent entry] If N is the root, go to CT6. Otherwise
            // let P be the parent of N, and let En be N's entry in P
            while (n.Level != this.TreeHeight)
            {
                parent = this.GetNode(this.Parents.Pop());
                parentEntry = this.ParentsEntry.Pop();

                // CT3 [Eliminiate under-full node] If N has too few entries,
                // delete En from P and add N to the list of eliminated nodes
                if (n.EntryCount < this.MinNodeEntries)
                {
                    parent.DeleteEntry(parentEntry, this.MinNodeEntries);
                    eliminatedNodeIds.Push(n.NodeId);
                }
                else
                {
                    // CT4 [Adjust covering rectangle] If N has not been eliminated,
                    // adjust EnI to tightly contain all entries in N
                    if (!n.Mbr.Equals(parent.Entries[parentEntry]))
                    {
                        this.OldRectangle.Set(parent.Entries[parentEntry].Min, parent.Entries[parentEntry].Max);
                        parent.Entries[parentEntry].Set(n.Mbr.Min, n.Mbr.Max);
                        parent.RecalculateMbr(this.OldRectangle);
                    }
                }
                // CT5 [Move up one level in tree] Set N=P and repeat from CT2
                n = parent;
            }

            // CT6 [Reinsert orphaned entries] Reinsert all entries of nodes in set Q.
            // Entries from eliminated leaf nodes are reinserted in tree leaves as in
            // Insert(), but entries from higher level nodes must be placed higher in
            // the tree, so that leaves of their dependent subtrees will be on the same
            // level as leaves of the main tree
            while (eliminatedNodeIds.Count > 0)
            {
                Node<T> e = this.GetNode(eliminatedNodeIds.Pop());
                for (int j = 0; j < e.EntryCount; j++)
                {
                    this.Add(e.Entries[j], e.Ids[j], e.Level);
                    e.Entries[j] = null;
                }
                e.EntryCount = 0;
                this.DeletedNodeIds.Push(e.NodeId);
                this.NodeMap.Remove(e.NodeId);
            }
        }

        /// <summary>
        /// Used by add(). Chooses a leaf to add the rectangle to.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="level"></param>
        private Node<T> ChooseNode(Rectangle r, int level)
        {
            // CL1 [Initialize] Set N to be the root node
            Node<T> n = this.GetNode(this.RootNodeId);
            this.Parents.Clear();
            this.ParentsEntry.Clear();

            // CL2 [Leaf check] If N is a leaf, return N
            while (true)
            {
                if (n == null)
                {
                    Debug.WriteLine($"Could not get root Node<T> ({this.RootNodeId})");
                    throw new InvalidOperationException($"Could not get root Node<T> ({this.RootNodeId})");
                }

                if (n?.Level == level)
                {
                    return n;
                }

                // CL3 [Choose subtree] If N is not at the desired level, let F be the entry in N
                // whose rectangle FI needs least enlargement to include EI. Resolve
                // ties by choosing the entry with the rectangle of smaller area.
                float leastEnlargement = n.GetEntry(0).Enlargement(r);
                int index = 0; // index of rectangle in subtree
                for (int i = 1; i < n.EntryCount; i++)
                {
                    Rectangle tempRectangle = n.GetEntry(i);
                    float tempEnlargement = tempRectangle.Enlargement(r);
                    if ((tempEnlargement < leastEnlargement) ||
                        ((tempEnlargement == leastEnlargement) &&
                         (tempRectangle.Area() < n.GetEntry(index).Area())))
                    {
                        index = i;
                        leastEnlargement = tempEnlargement;
                    }
                }

                this.Parents.Push(n.NodeId);
                this.ParentsEntry.Push(index);

                // CL4 [Descend until a leaf is reached] Set N to be the child Node&lt;T&gt;
                // pointed to by Fp and repeat from CL2
                n = this.GetNode(n.Ids[index]);
            }
        }

        /// <summary>
        /// Ascend from a leaf Node&lt;T&gt; L to the root, adjusting covering rectangles and
        /// propagating Node&lt;T&gt; splits as necessary.
        /// </summary>
        private Node<T> AdjustTree(Node<T> n, Node<T> nn)
        {
            // AT1 [Initialize] Set N=L. If L was split previously, set NN to be
            // the resulting second node.

            // AT2 [Check if done] If N is the root, stop
            while (n.Level != this.TreeHeight)
            {
                // AT3 [Adjust covering rectangle in parent entry] Let P be the parent
                // Node<T> of N, and let En be N's entry in P. Adjust EnI so that it tightly
                // encloses all entry rectangles in N.
                Node<T> parent = this.GetNode(this.Parents.Pop());
                int entry = this.ParentsEntry.Pop();

                if (parent.Ids[entry] != n.NodeId)
                {
                    Debug.WriteLine($"Error: entry {entry} in Node<T> {parent.NodeId} should point to Node<T> {n.NodeId}; actually points to Node<T> {parent.Ids[entry]}");
                }

                if (!parent.Entries[entry].Equals(n.Mbr))
                {
                    parent.Entries[entry].Set(n.Mbr.Min, n.Mbr.Max);
                    parent.Mbr.Set(parent.Entries[0].Min, parent.Entries[0].Max);
                    for (int i = 1; i < parent.EntryCount; i++)
                    {
                        parent.Mbr.Add(parent.Entries[i]);
                    }
                }

                // AT4 [Propagate Node<T> split upward] If N has a partner NN resulting from
                // an earlier split, create a new entry Enn with Ennp pointing to NN and
                // Enni enclosing all rectangles in NN. Add Enn to P if there is room.
                // Otherwise, invoke splitNode to produce P and PP containing Enn and
                // all P's old entries.
                Node<T> newNode = null;
                if (nn != null)
                {
                    if (parent.EntryCount < this.MaxNodeEntries)
                    {
                        parent.AddEntry(nn.Mbr, nn.NodeId);
                    }
                    else
                    {
                        newNode = this.SplitNode(parent, nn.Mbr.Copy(), nn.NodeId);
                    }
                }

                // AT5 [Move up to next level] Set N = P and set NN = PP if a split
                // occurred. Repeat from AT2
                n = parent;
                nn = newNode;

                parent = null;
                newNode = null;
            }

            return nn;
        }

        /// <summary>
        /// Check the consistency of the tree.
        /// </summary>
        private void CheckConsistency(int nodeId, int expectedLevel, Rectangle expectedMbr)
        {
            // go through the tree, and check that the internal data structures of
            // the tree are not corrupted.
            Node<T> n = this.GetNode(nodeId);

            if (n == null)
            {
                Debug.WriteLine($"Error: Could not read Node<T> {nodeId}");
            }

            if (n?.Level != expectedLevel)
            {
                Debug.WriteLine($"Error: Node<T> {nodeId}, expected level {expectedLevel}, actual level {n?.Level}");
            }

            Rectangle calculatedMbr = this.CalculateMbr(n);

            if (n?.Mbr.Equals(calculatedMbr) == false)
            {
                Debug.WriteLine($"Error: Node<T> {nodeId}, calculated MBR does not equal stored MBR");
            }

            if (expectedMbr != null && !n.Mbr.Equals(expectedMbr))
            {
                Debug.WriteLine($"Error: Node<T> {nodeId}, expected MBR (from parent) does not equal stored MBR");
            }

            // Check for corruption where a parent entry is the same object as the child MBR
            if (expectedMbr != null && n.Mbr.SameObject(expectedMbr))
            {
                Debug.WriteLine($"Error: Node<T> {nodeId} MBR using same rectangle object as parent's entry");
            }

            for (int i = 0; i < n.EntryCount; i++)
            {
                if (n.Entries[i] == null)
                {
                    Debug.WriteLine($"Error: Node<T> {nodeId}, Entry {i} is null");
                }

                if (n.Level > 1)
                { // if not a leaf
                    this.CheckConsistency(n.Ids[i], n.Level - 1, n.Entries[i]);
                }
            }
        }

        /// <summary>
        /// Given a Node<T> object, calculate the Node<T> MBR from it's entries.
        /// Used in consistency checking
        /// </summary>
        /// <param name="n"></param>
        private Rectangle CalculateMbr(Node<T> n)
        {
            Rectangle mbr = new Rectangle(n.Entries[0].Min, n.Entries[0].Max);

            for (int i = 1; i < n.EntryCount; i++)
            {
                mbr.Add(n.Entries[i]);
            }
            return mbr;
        }

        public int Count
        {
            get
            {
                this.Locker.AcquireReaderLock(LOCKING_TIMEOUT);

                int size = this.Msize;

                this.Locker.ReleaseReaderLock();

                return size;
            }
        }
    }
}