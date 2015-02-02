// SwoptSharp -- a collection of swarm intelligence algorithms for general optimisation purposes
// Copyright (C) 2015  Aleksander Palkowski
// 
// This program is free software; you can redistribute it and/or modify it under the terms of the
// GNU General Public License as published by the Free Software Foundation; either version 2 of the
// License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without
// even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// General Public License for more details.
// 
// You should have received a copy of the GNU General Public License along with this program; if
// not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA
// 02110-1301 USA.

using System.Collections.ObjectModel;

namespace SwoptSharp
{
    /// <summary>
    /// Represents a strongly typed collection of <see cref="Node&lt;T&gt;"/> objects.
    /// </summary>
    /// <typeparam name="T">The value type of nodes in the list.</typeparam>
    public class NodeList<T> : Collection<Node<T>>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeList&lt;T&gt;"/> class that is empty
        /// and has the default initial capacity.
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