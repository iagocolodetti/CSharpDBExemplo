using System.Collections.Generic;

/* iagocolodetti */

namespace CSharpDBExemplo
{
    interface ContatoDAO
    {
        void Add(Contato contato);

        Contato GetContato(int id);

        List<Contato> GetContatosPorNome(string nome);

        List<Contato> GetContatosPorTelefone(string telefone);

        List<Contato> GetContatosPorEmail(string email);

        List<Contato> GetContatos();

        void Update(Contato contato);

        void Delete(int id);
    }
}
