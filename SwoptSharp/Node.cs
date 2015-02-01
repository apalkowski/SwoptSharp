namespace SwoptSharp
{
    public class Node<T>
    {
        #region Private Fields

        private T data;
        private NodeList<T> neighbors = null;

        #endregion Private Fields

        #region Public Constructors

        public Node()
        {
        }

        public Node(T data)
            : this(data, null)
        {
        }

        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }

        #endregion Public Constructors

        #region Public Properties

        public T Value
        {
            get { return data; }
            set { data = value; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected NodeList<T> Neighbors
        {
            get { return neighbors; }
            set { neighbors = value; }
        }

        #endregion Protected Properties
    }
}