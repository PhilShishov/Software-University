namespace Repository
{
    using System.Collections.Generic;
    using System.Linq;

    public class Repository
    {
        private Dictionary<Person, int> data;

        public Repository()
        {
            this.data = new Dictionary<Person, int>();
        }

        public int Count => this.data.Keys.Count();

        public void Add(Person person)
        {
            this.data.Add(person, 0 + this.Count);
        }

        public Person Get(int id)
        {
            var person = this.data.FirstOrDefault(p => p.Value == id);
            return person.Key;
        }

        public bool Update(int id, Person newPerson)
        {
            bool isExists = false;

            var personToReplace = this.data.FirstOrDefault(p => p.Value == id);

            if (personToReplace.Key != null)
            {
                newPerson = personToReplace.Key;
                isExists = true;
            }

            return isExists;
        }

        public bool Delete(int id)
        {
            bool isExists = false;

            var personToDelete = this.data.FirstOrDefault(p => p.Value == id);

            if (personToDelete.Key != null)
            {
                this.data.Remove(personToDelete.Key);

                isExists = true;
            }

            return isExists;
        }
    }
}
