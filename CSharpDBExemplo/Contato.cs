
/* iagocolodetti */

namespace CSharpDBExemplo
{
    class Contato
    {
        private int id;
        private string nome,
                       telefone,
                       email;

        public Contato() { }

        public Contato(string nome, string telefone, string email)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;
        }

        public Contato(int id, string nome, string telefone, string email)
        {
            this.id = id;
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Nome
        {
            get => nome;
            set => nome = value;
        }

        public string Telefone
        {
            get => telefone;
            set => telefone = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }
    }
}
