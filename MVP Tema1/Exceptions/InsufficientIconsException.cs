using System;

namespace MVP_Tema1.Exceptions
{
    internal class InsufficientIconsException : Exception
    {
        private const string DefaultMessage = "There are not enough icons in the folder";

        public InsufficientIconsException()
            : base(DefaultMessage)
        {
        }
    }
}
