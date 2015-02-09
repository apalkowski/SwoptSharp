using System.Collections.Generic;

namespace SwoptSharp
{
    public class GraphNode<T> : Node<T>
    {
        #region Private Fields

        private List<double> costs;

        #endregion Private Fields

        #region Public Constructors

        public GraphNode()
        {
        }

        public GraphNode(T value)
            : base(value)
        {
        }

        public GraphNode(T value, NodeList<T> neighbors)
            : base(value, neighbors)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public List<double> Costs
        {
            get
            {
                if (costs == null)
                {
                    costs = new List<double>();
                }

                return costs;
            }
        }

        public new NodeList<T> Neighbors
        {
            get
            {
                if (base.Neighbors == null)
                {
                    base.Neighbors = new NodeList<T>();
                }

                return base.Neighbors;
            }
        }

        #endregion Public Properties
    }
}