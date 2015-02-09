using System;

namespace SwoptSharp
{
    [Serializable]
    public class NodeAlreadyExistsException : Exception
    {
        #region Private Fields

        private const string defaultMessage = "There is already a node with the specified key value.";

        #endregion Private Fields

        #region Public Constructors

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

        #endregion Public Constructors

        #region Protected Constructors

        protected NodeAlreadyExistsException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Protected Constructors
    }

    [Serializable]
    public class NodeNotFoundException : Exception
    {
        #region Private Fields

        private const string defaultMessage = "Node has not been found.";

        #endregion Private Fields

        #region Public Constructors

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

        #endregion Public Constructors

        #region Protected Constructors

        protected NodeNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Protected Constructors
    }
}