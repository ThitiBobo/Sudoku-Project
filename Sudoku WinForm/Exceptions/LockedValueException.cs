using System;
using System.Runtime.Serialization;

namespace Sudoku_WinForm
{
    /// <summary>
    /// Exception levée quand une valeur bloquée tente d'être modifiée.
    /// </summary>
    [Serializable]
    internal class LockedValueException : Exception
    {
        public LockedValueException()
        {
        }

        public LockedValueException(string message) : base(message)
        {
        }

        public LockedValueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LockedValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}