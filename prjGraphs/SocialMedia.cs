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

        public List<Person> getShortestPath(Person start, Person end)
        {
            //queue for people needed to visist, start from first person
            var queue = new Queue<Person>();    
            queue.Enqueue(start);

            //set tp keep track of poeple weve already visited
            var visited = new HashSet<Person> { start };

            //dictionary to reconstruct path backwards, storing child -> parent
            var parentMap = new Dictionary<Person, Person>();

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                //if we found the person, done
                if (current == end)
                {
                    break; //stop looping
                }

                //look through all friends of current person
                foreach (var friend in current.friends)
                {
                    //if we havent visited this friend yet
                    if (!visited.Contains(friend))
                    {
                        visited.Add(friend); //mark them as visisted
                        parentMap[friend] = current; //store how to get to the friend
                        queue.Enqueue(friend);
                    }
                }
            }

            //PATH RECONSTRUCTION
            //if we never found them, theyre disconnected
            if (!parentMap.ContainsKey(end))
            {
                return null; //or return empty list
            }

            var path = new List<Person>();
            var person = end;
            while (person != null)
            {
                path.Add(person);
                parentMap.TryGetValue(person, out person); //move backwards through parent map
            }

            //path is backwards so we reverse it to get start -> end
            path.Reverse();
            return path;
            //traversal BFS
        }
    }
}
