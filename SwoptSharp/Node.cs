#region License

// SwoptSharp, a collection of swarm intelligence algorithms for general optimisation purposes
// Copyright (C) 2015  Aleksander Palkowski <http://apalkowski.com>
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

#endregion License

namespace SwoptSharp
{
    public class Node<T>
    {
        private T data;
        private NodeList<T> neighbors = null;

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

        /// <summary>
        /// A unique key value assigned to the node.
        /// </summary>
        public T Value
        {
            get { return data; }
            set { data = value; }
        }

        protected NodeList<T> Neighbors
        {
            get { return neighbors; }
            set { neighbors = value; }
        }
    }
}