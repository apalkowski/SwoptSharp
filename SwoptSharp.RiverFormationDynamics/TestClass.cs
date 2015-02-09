using SwoptSharp;

namespace SwoptSharp.RiverFormationDynamics
{
    public class TestClass
    {
        public void TestMethod()
        {
            var a = new Graph<int>();
            var aNode1 = new GraphNode<int>(11);
            var aNode2 = new GraphNode<int>(22);
            var aNode3 = new GraphNode<int>(33);
            a.AddNode(aNode1);
            a.AddNode(aNode2);
            a.AddNode(aNode3);

            a.AddUndirectedEdge(aNode1, aNode2, 12);
            a.AddUndirectedEdge(aNode1, aNode3, 13);

            foreach (var item in a)
            {
                string aTxt = item.ToString();
            }

            foreach (GraphNode<int> node in a.Nodes)
            {
                foreach (GraphNode<int> neighbour in node.Neighbors)
                {
                    neighbour.Value = 0;
                }
            }
        }
    }
}
