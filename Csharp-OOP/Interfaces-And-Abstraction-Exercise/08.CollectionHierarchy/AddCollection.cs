using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    public class AddCollection : IAdd
    {
        private List<string> collection = new List<string>();
        public IReadOnlyCollection<string> Collection => this.collection.AsReadOnly();

        public int Add(string item)
        {
            this.collection.Add(item);
            return this.collection.Count - 1;
        }

    }
}
