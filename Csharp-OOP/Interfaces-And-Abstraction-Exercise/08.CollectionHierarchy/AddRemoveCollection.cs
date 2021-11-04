using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    public class AddRemoveCollection : IAdd, IRemove
    {
        private List<string> collection = new List<string>();
        public int Add(string item)
        {
            this.collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {          
           string removed = this.collection[this.collection.Count - 1];
            this.collection.RemoveAt(this.collection.Count - 1);
            return removed;

        }
    }
}
