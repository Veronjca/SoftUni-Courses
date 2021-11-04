using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    public class MyList : IAdd, IRemove
    {
        private List<string> collection = new List<string>();

        public int Used => this.collection.Count;
        public int Add(string item)
        {
            this.collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string removed = this.collection[0];
            this.collection.RemoveAt(0);
            return removed;
        }
    }
}
