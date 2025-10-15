using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjGraphs
{
    public class Person
    {
        public Person(string name)
        {
            this.name = name;
            friends = new List<Person>();
        }

        public string name { get; }
        public List<Person> friends { get; set; }

        //helper method to aadd a friendship (an edge)
        public void addFriend(Person person)
        {
            //add new person if they arent already there
            if (!friends.Contains(person))
            {
                friends.Add(person);
            }

            //add person to new friends list
            if (!person.friends.Contains(this))
            {
                person.friends.Add(this);
            }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
