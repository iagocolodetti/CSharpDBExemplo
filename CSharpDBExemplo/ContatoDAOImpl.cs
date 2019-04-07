using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

/* iagocolodetti */

namespace CSharpDBExemplo
{
    class ContatoDAOImpl : ContatoDAO
    {
        private ConnectionFactory cf;

        public ContatoDAOImpl()
        {
            cf = new ConnectionFactory();
        }

        public void Add(Contato contato)
        {
            MySqlConnection con = cf.GetConnection();
            if (con != null && cf.IsConnectionOpen(con))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO contato(nome, telefone, email) VALUES(@nome, @telefone, @email)", con);
                    MySqlParameter nome = new MySqlParameter("@nome", MySqlDbType.VarChar, 45);
                    MySqlParameter telefone = new MySqlParameter("@telefone", MySqlDbType.VarChar, 45);
                    MySqlParameter email = new MySqlParameter("@email", MySqlDbType.VarChar, 45);
                    nome.Value = contato.Nome;
                    telefone.Value = contato.Telefone;
                    email.Value = contato.Email;
                    cmd.Parameters.Add(nome);
                    cmd.Parameters.Add(telefone);
                    cmd.Parameters.Add(email);
                    cmd.Prepare();
                    if (cmd.ExecuteNonQuery() == 0) throw new ContatoException("Contato não adicionado.");
                }
                catch (MySqlException e)
                {
#if DEBUG
                    Console.WriteLine(e.ToString());
#else
                    Console.WriteLine("Não foi possível adicionar o contato.");
#endif
                }
                finally
                {
                    cf.CloseConnection(con);
                }
            }
        }

        public Contato GetContato(int id)
        {
            MySqlConnection con = cf.GetConnection();
            Contato contato = null;
            if (con != null && cf.IsConnectionOpen(con))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM contato WHERE id = @id", con);
                    MySqlParameter _id = new MySqlParameter("@id", MySqlDbType.Int32, 11);
                    _id.Value = id;
                    cmd.Parameters.Add(_id);
                    cmd.Prepare();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        contato = new Contato((int)reader["id"], (string)reader["nome"], (string)reader["telefone"], (string)reader["email"]);
                    }
                    if (contato == null)
                    {
                        throw new ContatoNaoExisteException("Não existe contato com esse ID.");
                    }
                }
                catch (MySqlException e)
                {
#if DEBUG
                    Console.WriteLine(e.ToString());
#else
                    Console.WriteLine("Não foi possível buscar o contato.");
#endif
                }
                finally
                {
                    cf.CloseConnection(con);
                }
            }
            return contato;
        }

        public List<Contato> GetContatosPorNome(string nome)
        {
            MySqlConnection con = cf.GetConnection();
            List<Contato> contatos = new List<Contato>();
            if (con != null && cf.IsConnectionOpen(con))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM contato WHERE nome LIKE @nome", con);
                    MySqlParameter _nome = new MySqlParameter("@nome", MySqlDbType.VarChar, 45);
                    _nome.Value = "%" + nome + "%";
                    cmd.Parameters.Add(_nome);
                    cmd.Prepare();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Contato contato = new Contato((int)reader["id"], (string)reader["nome"], (string)reader["telefone"], (string)reader["email"]);
                        contatos.Add(contato);
                    }
                    if (contatos.Count == 0)
                    {
                        throw new ContatoNaoExisteException("Não existem contatos com esse nome ou parte dele.");
                    }
                }
                catch (MySqlException e)
                {
#if DEBUG
                    Console.WriteLine(e.ToString());
#else
                    Console.WriteLine("Não foi possível buscar os contatos.");
#endif
                }
                finally
                {
                    cf.CloseConnection(con);
                }
            }
            return contatos;
        }

        public List<Contato> GetContatosPorTelefone(string telefone)
        {
            MySqlConnection con = cf.GetConnection();
            List<Contato> contatos = new List<Contato>();
            if (con != null && cf.IsConnectionOpen(con))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM contato WHERE telefone LIKE @telefone", con);
                    MySqlParameter _telefone = new MySqlParameter("@telefone", MySqlDbType.VarChar, 45);
                    _telefone.Value = "%" + telefone + "%";
                    cmd.Parameters.Add(_telefone);
                    cmd.Prepare();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Contato contato = new Contato((int)reader["id"], (string)reader["nome"], (string)reader["telefone"], (string)reader["email"]);
                        contatos.Add(contato);
                    }
                    if (contatos.Count == 0)
                    {
                        throw new ContatoNaoExisteException("Não existem contatos com esse telefone ou parte dele.");
                    }
                }
                catch (MySqlException e)
                {
#if DEBUG
                    Console.WriteLine(e.ToString());
#else
                    Console.WriteLine("Não foi possível buscar os contatos.");
#endif
                }
                finally
                {
                    cf.CloseConnection(con);
                }
            }
            return contatos;
        }

        public List<Contato> GetContatosPorEmail(string email)
        {
            MySqlConnection con = cf.GetConnection();
            List<Contato> contatos = new List<Contato>();
            if (con != null && cf.IsConnectionOpen(con))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM contato WHERE email LIKE @email", con);
                    MySqlParameter _email = new MySqlParameter("@email", MySqlDbType.VarChar, 45);
                    _email.Value = "%" + email + "%";
                    cmd.Parameters.Add(_email);
                    cmd.Prepare();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Contato contato = new Contato((int)reader["id"], (string)reader["nome"], (string)reader["telefone"], (string)reader["email"]);
                        contatos.Add(contato);
                    }
                    if (contatos.Count == 0)
                    {
                        throw new ContatoNaoExisteException("Não existem contatos com esse email ou parte dele.");
                    }
                }
                catch (MySqlException e)
                {
#if DEBUG
                    Console.WriteLine(e.ToString());
#else
                    Console.WriteLine("Não foi possível buscar os contatos.");
#endif
                }
                finally
                {
                    cf.CloseConnection(con);
                }
            }
            return contatos;
        }

        public List<Contato> GetContatos()
        {
            MySqlConnection con = cf.GetConnection();
            List<Contato> contatos = new List<Contato>();
            if (con != null && cf.IsConnectionOpen(con))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM contato", con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Contato contato = new Contato((int)reader["id"], (string)reader["nome"], (string)reader["telefone"], (string)reader["email"]);
                        contatos.Add(contato);
                    }
                    if (contatos.Count == 0)
                    {
                        throw new ContatoNaoExisteException("Não existem contatos.");
                    }
                }
                catch (MySqlException e)
                {
#if DEBUG
                    Console.WriteLine(e.ToString());
#else
                    Console.WriteLine("Não foi possível adicionar o contato.");
#endif
                }
                finally
                {
                    cf.CloseConnection(con);
                }
            }
            return contatos;
        }

        public void Update(Contato contato)
        {
            MySqlConnection con = cf.GetConnection();
            if (con != null && cf.IsConnectionOpen(con))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE contato SET nome = @nome, telefone = @telefone, email = @email WHERE id = @id", con);
                    MySqlParameter nome = new MySqlParameter("@nome", MySqlDbType.VarChar, 45);
                    MySqlParameter telefone = new MySqlParameter("@telefone", MySqlDbType.VarChar, 45);
                    MySqlParameter email = new MySqlParameter("@email", MySqlDbType.VarChar, 45);
                    MySqlParameter id = new MySqlParameter("@id", MySqlDbType.Int32, 11);
                    nome.Value = contato.Nome;
                    telefone.Value = contato.Telefone;
                    email.Value = contato.Email;
                    id.Value = contato.Id;
                    cmd.Parameters.Add(nome);
                    cmd.Parameters.Add(telefone);
                    cmd.Parameters.Add(email);
                    cmd.Parameters.Add(id);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    if (cmd.ExecuteNonQuery() == 0) throw new ContatoNaoExisteException("Não existe contato com esse ID.");
                }
                catch (MySqlException e)
                {
#if DEBUG
                    Console.WriteLine(e.ToString());
#else
                    Console.WriteLine("Não foi possível adicionar o contato.");
#endif
                }
                finally
                {
                    cf.CloseConnection(con);
                }
            }
        }

        public void Delete(int id)
        {
            MySqlConnection con = cf.GetConnection();
            if (con != null && cf.IsConnectionOpen(con))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM contato WHERE id = @id", con);
                    MySqlParameter _id = new MySqlParameter("@id", MySqlDbType.Int32, 11);
                    _id.Value = id;
                    cmd.Parameters.Add(_id);
                    cmd.Prepare();
                    if (cmd.ExecuteNonQuery() == 0) throw new ContatoNaoExisteException();
                }
                catch (MySqlException e)
                {
#if DEBUG
                    Console.WriteLine(e.ToString());
#else
                    Console.WriteLine("Não foi possível adicionar o contato.");
#endif
                }
                finally
                {
                    cf.CloseConnection(con);
                }
            }
        }
    }
}
