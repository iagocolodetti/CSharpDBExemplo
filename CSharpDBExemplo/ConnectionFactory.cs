using System;
using MySql.Data.MySqlClient;
using System.Data;

/* iagocolodetti */

namespace CSharpDBExemplo
{
    class ConnectionFactory
    {
        private const string SERVER = "localhost",
                             PORT = "3306",
                             DATABASE = "contatodb",
                             UID = "root",
                             PWD = "root";

        public MySqlConnection GetConnection()
        {
            MySqlConnection con = null;
            try
            {
                con = new MySqlConnection("SERVER=" + SERVER + ";PORT=" + PORT + ";DATABASE=" + DATABASE + ";UID=" + UID + ";PWD=" + PWD + ";");
                con.Open();
            }
            catch (MySqlException e)
            {
#if DEBUG
                Console.WriteLine(e.ToString());
#else
                Console.WriteLine("Não foi possível realizar a conexão.");
#endif
            }
            return con;
        }

        public bool IsConnectionOpen(MySqlConnection con)
        {
            return (con.State == ConnectionState.Open);
        }

        public void CloseConnection(MySqlConnection con)
        {
            try
            {
                con.Close();
            }
            catch (MySqlException e)
            {
#if DEBUG
                Console.WriteLine(e.ToString());
#else
                Console.WriteLine("Não foi possível encerrar a conexão.");
#endif
            }
        }
    }
}
