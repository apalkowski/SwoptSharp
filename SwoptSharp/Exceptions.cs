using System;

namespace SwoptSharp
{
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