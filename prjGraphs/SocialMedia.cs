using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjGraphs
{
    public class SocialMedia
    {
        public SocialMedia()
        {
            Members = new List<Person>();
        }

        public List<Person> Members { get; }

        //method to add new person (vertex) to network
        public Person addMember(string name)
        {
            var newMember = new Person(name);
            Members.Add(newMember);
            return newMember;
        }

        //helper prints netwokr connections
        public void printNetwork()
        {
            Console.WriteLine("--- Social Network Friendships ---");

            foreach (var member in Members)
            {
                //using string.join to list friends neatly
                var friendNames = member.friends.Select(x => x.name);
                Console.WriteLine($"{member.name} is friends with {string.Join(", ", friendNames)}");
            }
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
