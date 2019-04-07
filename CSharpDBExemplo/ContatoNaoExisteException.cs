using System;

/* iagocolodetti */

namespace CSharpDBExemplo
{
    [Serializable]
    class ContatoNaoExisteException : Exception
    {
        public ContatoNaoExisteException()
            : base("Contato não existe.")
        {

        }

        public ContatoNaoExisteException(string message)
            : base(message)
        {

        }
    }
}
