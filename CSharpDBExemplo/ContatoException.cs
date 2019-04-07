using System;

/* iagocolodetti */

namespace CSharpDBExemplo
{
    [Serializable]
    class ContatoException : Exception
    {
        public ContatoException(string message)
            : base(message)
        {

        }
    }
}
