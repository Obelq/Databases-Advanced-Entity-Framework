using System;
using System.Collections.Generic;
using System.Linq;


namespace ClassPerson
{
    class Family
    {
        private List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public Person GetOldestMember()
        {
            return people.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }
}
