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

using System;

namespace SwoptSharp
{
    [Serializable]
    public class NodeAlreadyExistsException : Exception
    {
        private const string defaultMessage = "There is already a node with the specified key value.";

        public NodeAlreadyExistsException()
            : base(defaultMessage)
        {
        }

        public NodeAlreadyExistsException(Exception innerException)
            : base(defaultMessage, innerException)
        {
        }

        public NodeAlreadyExistsException(string message)
            : base(message)
        {
        }

        public NodeAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected NodeAlreadyExistsException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }

    [Serializable]
    public class NodeNotFoundException : Exception
    {
        private const string defaultMessage = "Node has not been found.";

        public NodeNotFoundException()
            : base(defaultMessage)
        {
        }

        public NodeNotFoundException(Exception innerException)
            : base(defaultMessage, innerException)
        {
        }

        public NodeNotFoundException(string message)
            : base(message)
        {
        }

        public NodeNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected NodeNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}