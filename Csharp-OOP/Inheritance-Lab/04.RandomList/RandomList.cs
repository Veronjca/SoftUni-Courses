using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random = new Random();
        public string RandomString()
        {
            int index = random.Next(0, this.Count);
            return this[index];
        }
        public void Remove()
        {
            int index = random.Next(0, this.Count);
            this.RemoveAt(index);
        }
    }
}
