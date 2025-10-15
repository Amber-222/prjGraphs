namespace prjGraphs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //multi relationships can exists in graphs
            //in sense of not hardcoding values, json objects would be used to poulate the graph so you can search through the objects
            //create graph
            var myNetwork = new SocialMedia();

            // add people to the network (vetices)
            var alice = myNetwork.addMember("Alice");
            var bob = myNetwork.addMember("Bob");
            var haylee = myNetwork.addMember("Haylee");
            var diana = myNetwork.addMember("Diana");
            var daniel = myNetwork.addMember("Daniel");

            //create friendships (edges)
            alice.addFriend(bob); //alce and bob are friends
            alice.addFriend(haylee); //alce and haylee are friends
            bob.addFriend(daniel); //bob and diana are friends
            diana.addFriend(haylee); //diana and haylee are friends

            //daniel has no friends
            myNetwork.printNetwork();

            //finding shortest path from alice to daniel
            Console.WriteLine("Fidning shortest path from Alice to Daniel ... ");
            var path = myNetwork.getShortestPath(alice, daniel);

            if (path != null)
            {
                //use join to display path nicely
                Console.WriteLine($"Path found! It takes {path.Count - 1} steps");
                Console.WriteLine(string.Join(" -> ", path.Select(p => p.name)));
            }
            else
            {
                Console.WriteLine("No path found between ALice and Daniel");
            }
        }
    }
}
