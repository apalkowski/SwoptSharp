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
    public class GraphNode<T> : Node<T>
    {
        private List<double> costs;

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
    }
}