namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Family
    {
        private List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }

        //public List<Person> People
        //{
        //    get { return people; }
        //    set { people = value; }
        //}

        public void AddMember(Person member)
        {
            if (member == null)
            {
                throw new Exception();
            }
            people.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.people.OrderByDescending(x => x.Age).FirstOrDefault();
        }

    }
}
