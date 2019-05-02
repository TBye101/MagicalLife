using ProtoBuf;
using System.Collections.ObjectModel;

namespace MagicalLifeAPI.Entity.AI.Task
{
    /// <summary>
    /// Holds tasks that must be completed before another task can begin.
    /// </summary>
    [ProtoContract]
    public class Dependencies
    {
        [ProtoMember(1)]
        public ObservableCollection<MagicalTask> PreRequisite { get; private set; }

        /// <summary>
        /// The amount of prerequisites originally.
        /// </summary>
        [ProtoMember(2)]
        public int InitialCount;

        public Dependencies(ObservableCollection<MagicalTask> dependencies)
        {
            this.PreRequisite = dependencies;
            this.InitialCount = dependencies.Count;

            foreach (MagicalTask item in this.PreRequisite)
            {
                item.Completed += this.Item_Completed;
            }
            PreRequisite.CollectionChanged += this.PreRequisite_CollectionChanged;
        }

        private void PreRequisite_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            System.Collections.IList newItems = e.NewItems;

            if (newItems != null && newItems.Count > 0)
            {
                foreach (object item in newItems)
                {
                    MagicalTask task = (MagicalTask)item;
                    task.Completed += this.Item_Completed;
                }
            }
        }

        protected Dependencies()
        {
            //Protobuf-net constructor
        }

        [ProtoAfterDeserialization]
        protected void AfterDeserialization()
        {
            foreach (MagicalTask item in this.PreRequisite)
            {
                item.Completed += this.Item_Completed;
            }
        }

        private void Item_Completed(MagicalTask task)
        {
            this.PreRequisite.Remove(task);
        }

        /// <summary>
        /// Creates an empty dependencies object. For use when a task doesn't have dependencies.
        /// </summary>
        /// <returns></returns>
        public static Dependencies CreateEmpty()
        {
            return new Dependencies(new ObservableCollection<MagicalTask>());
        }
    }
}