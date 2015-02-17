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

using System.Collections.Generic;

namespace SwoptSharp
{
    public class Graph<T> : IEnumerable<T>
    {
        private NodeList<T> nodeSet;

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

        public int Count
        {
            get { return nodeSet.Count; }
        }

        public NodeList<T> Nodes
        {
            get { return nodeSet; }
        }

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
    }
}