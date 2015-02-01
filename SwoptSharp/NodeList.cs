using System.Collections.ObjectModel;

namespace SwoptSharp
{
    /// <summary>
    /// Represents a strongly typed collection of <see cref="Node&lt;T&gt;"/> objects.
    /// </summary>
    /// <typeparam name="T">The value type of nodes in the list.</typeparam>
    /// <seealso cref="Node&lt;T&gt;"/>
    public class NodeList<T> : Collection<Node<T>>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeList&lt;T&gt;"/> class that is empty and has the default initial capacity.
        /// </summary>
        public NodeList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeList&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="initialSize">The number of nodes that the new list can initially store.</param>
        public NodeList(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
            {
                base.Items.Add(default(Node<T>));
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Searches the list for a node with the specified value.
        /// </summary>
        /// <param name="value">Value of the node to be found.</param>
        /// <returns>The node which value matches the specified one.</returns>
        public Node<T> FindByValue(T value)
        {
            foreach (Node<T> node in Items)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
            }

            return null;
        }

        #endregion Public Methods
    }
}