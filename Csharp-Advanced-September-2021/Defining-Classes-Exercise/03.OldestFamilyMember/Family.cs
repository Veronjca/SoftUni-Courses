using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            Members = new List<Person>();
        }
        public List<Person> Members { get; set; }

        public void AddMember(Person member)
        {
            this.Members.Add(member);
        }

        public Person GetOldestMember()
        {
            int maxAge = Members.Max(x => x.Age);
            return Members.First(member => member.Age == maxAge);

        }
    }
}
