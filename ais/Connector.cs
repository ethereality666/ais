using System.Data;
using MySql.Data.MySqlClient;

namespace ais
{
    public class Connector
    {
        MySqlConnection connection = new MySqlConnection("server=127.0.0.1;port=3306;username=aether;password=!Exc25125;database=ais");

        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }

        public void CloseConnection()
        {
            if(connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection GetConnection() => connection;
    }
}
