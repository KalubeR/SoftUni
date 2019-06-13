using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace OldestFamilyMember
{
    public class Family
    {
        private List<Person> members;

        public Family()
        {
            this.members = new List<Person>();
        }

        public List<Person> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }

        public void AddMember(Person member)
        {
            members.Add(member);
        }

        public Person GetOldestMember()
        {
            return Members.OrderByDescending(m => m.Age).FirstOrDefault();
        }
    }
}
