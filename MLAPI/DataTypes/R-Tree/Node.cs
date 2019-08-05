//   Node.java version 1.0b2p1
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

// Ported to C# By Dror Gluska, April 9th, 2009
namespace MLAPI.DataTypes
{
    /// <summary>
    /// Used by RTree. There are no public methods in this class.
    /// </summary>
    internal class Node<T>
    {
        internal int NodeId;
        internal Rectangle Mbr;
        internal Rectangle[] Entries;
        internal int[] Ids;
        internal int Level;
        internal int EntryCount;

        public Node(int nodeId, int level, int maxNodeEntries)
        {
            this.NodeId = nodeId;
            this.Level = level;
            this.Entries = new Rectangle[maxNodeEntries];
            this.Ids = new int[maxNodeEntries];
        }

        internal void AddEntry(Rectangle r, int id)
        {
            this.Ids[this.EntryCount] = id;
            this.Entries[this.EntryCount] = r.Copy();
            this.EntryCount++;
            if (this.Mbr == null)
            {
                this.Mbr = r.Copy();
            }
            else
            {
                this.Mbr.Add(r);
            }
        }

        internal void AddEntryNoCopy(Rectangle r, int id)
        {
            this.Ids[this.EntryCount] = id;
            this.Entries[this.EntryCount] = r;
            this.EntryCount++;
            if (this.Mbr == null)
            {
                this.Mbr = r.Copy();
            }
            else
            {
                this.Mbr.Add(r);
            }
        }

        /// <summary>
        /// Return the index of the found entry, or -1 if not found
        /// </summary>
        /// <param name="r"></param>
        /// <param name="id"></param>
        internal int FindEntry(Rectangle r, int id)
        {
            for (int i = 0; i < this.EntryCount; i++)
            {
                if (id == this.Ids[i] && r.Equals(this.Entries[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        // delete entry. This is done by setting it to null and copying the last entry into its space.

        /// <summary>
        /// delete entry. This is done by setting it to null and copying the last entry into its space.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="minNodeEntries"></param>
        internal void DeleteEntry(int i, int minNodeEntries)
        {
            int lastIndex = this.EntryCount - 1;
            Rectangle deletedRectangle = this.Entries[i];
            this.Entries[i] = null;
            if (i != lastIndex)
            {
                this.Entries[i] = this.Entries[lastIndex];
                this.Ids[i] = this.Ids[lastIndex];
                this.Entries[lastIndex] = null;
            }
            this.EntryCount--;

            // if there are at least minNodeEntries, adjust the MBR.
            // otherwise, don't bother, as the Node<T> will be
            // eliminated anyway.
            if (this.EntryCount >= minNodeEntries)
            {
                this.RecalculateMbr(deletedRectangle);
            }
        }

        /// <summary>
        /// oldRectangle is a rectangle that has just been deleted or made smaller.
        /// Thus, the MBR is only recalculated if the OldRectangle influenced the old MBR
        /// </summary>
        /// <param name="deletedRectangle"></param>
        internal void RecalculateMbr(Rectangle deletedRectangle)
        {
            if (this.Mbr.EdgeOverlaps(deletedRectangle))
            {
                this.Mbr.Set(this.Entries[0].Min, this.Entries[0].Max);

                for (int i = 1; i < this.EntryCount; i++)
                {
                    this.Mbr.Add(this.Entries[i]);
                }
            }
        }

        /// <summary>
        /// Gets the entry count.
        /// </summary>
        /// <returns></returns>
        public int GetEntryCount()
        {
            return this.EntryCount;
        }

        /// <summary>
        /// Gets the entry.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Rectangle GetEntry(int index)
        {
            if (index < this.EntryCount)
            {
                return this.Entries[index];
            }
            return null;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public int GetId(int index)
        {
            if (index < this.EntryCount)
            {
                return this.Ids[index];
            }
            return -1;
        }

        /// <summary>
        /// eliminate null entries, move all entries to the start of the source node
        /// </summary>
        /// <param name="rtree"></param>
        internal void Reorganize(RTree<T> rtree)
        {
            int countdownIndex = rtree.MaxNodeEntries - 1;
            for (int index = 0; index < this.EntryCount; index++)
            {
                if (this.Entries[index] == null)
                {
                    while (this.Entries[countdownIndex] == null && countdownIndex > index)
                    {
                        countdownIndex--;
                    }
                    this.Entries[index] = this.Entries[countdownIndex];
                    this.Ids[index] = this.Ids[countdownIndex];
                    this.Entries[countdownIndex] = null;
                }
            }
        }

        internal bool IsLeaf()
        {
            return (this.Level == 1);
        }

        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <returns></returns>
        public int GetLevel()
        {
            return this.Level;
        }

        /// <summary>
        /// Gets the MBR.
        /// </summary>
        /// <returns></returns>
        public Rectangle GetMbr()
        {
            return this.Mbr;
        }
    }
}