using System.Collections.Generic;

namespace SwoptSharp
{
    public class Graph<T> : IEnumerable<T>
    {
        #region Private Fields

        private NodeList<T> nodeSet;

        #endregion Private Fields

        #region Public Constructors

        public Graph()
            : this(null)
        {
        }

        public Graph(NodeList<T> nodeSet)
        {
            if (nodeSet == null)
            {
                this.nodeSet = new NodeList<T>();
            }
            else
            {
                this.nodeSet = nodeSet;
            }
        }

        #endregion Public Constructors

        #region Public Properties

        public int Count
        {
            get { return nodeSet.Count; }
        }

        public NodeList<T> Nodes
        {
            get { return nodeSet; }
        }

        #endregion Public Properties

        #region Public Methods

        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, double cost)
        {
            from.Neighbors.Add(to);
            from.Costs.Add(cost);
        }

        public void AddDirectedEdge(T fromKey, T toKey, double cost)
        {
            GraphNode<T> from = (GraphNode<T>)nodeSet.FindByValue(fromKey);
            GraphNode<T> to = (GraphNode<T>)nodeSet.FindByValue(toKey);

            if ((from == null) || (to == null))
            {
                throw new NodeNotFoundException();
            }

            AddDirectedEdge(from, to, cost);
        }

        public void AddNode(GraphNode<T> node)
        {
            if (this.Contains(node.Value))
            {
                throw new NodeAlreadyExistsException();
            }
            nodeSet.Add(node);
        }

        public void AddNode(T value)
        {
            if (this.Contains(value))
            {
                throw new NodeAlreadyExistsException();
            }
            nodeSet.Add(new GraphNode<T>(value));
        }

        public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to, double cost)
        {
            from.Neighbors.Add(to);
            from.Costs.Add(cost);

            to.Neighbors.Add(from);
            to.Costs.Add(cost);
        }

        public void AddUndirectedEdge(T fromKey, T toKey, double cost)
        {
            GraphNode<T> from = (GraphNode<T>)nodeSet.FindByValue(fromKey);
            GraphNode<T> to = (GraphNode<T>)nodeSet.FindByValue(toKey);

            if ((from == null) || (to == null))
            {
                throw new NodeNotFoundException();
            }

            AddUndirectedEdge(from, to, cost);
        }

        public bool Contains(T value)
        {
            return nodeSet.FindByValue(value) != null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            //throw new NotImplementedException();
            return (IEnumerator<T>)this.nodeSet.GetEnumerator();
        }

        public bool Remove(T value)
        {
            GraphNode<T> nodeToRemove = (GraphNode<T>)nodeSet.FindByValue(value);
            if (nodeToRemove == null)
            {
                return false;
            }

            nodeSet.Remove(nodeToRemove);

            foreach (GraphNode<T> gnode in this.nodeSet)
            {
                int index = gnode.Neighbors.IndexOf(nodeToRemove);
                if (index != -1)
                {
                    gnode.Neighbors.RemoveAt(index);
                    gnode.Costs.RemoveAt(index);
                }
            }

            return true;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            //throw new NotImplementedException();
            return this.GetEnumerator();
        }

        #endregion Public Methods
    }
}