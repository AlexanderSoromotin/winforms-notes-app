using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Zametki_Bal_Kuz
{
    internal class DB
    {
        // Параметры подключения к БД
        private static string host = "localhost";
        private static string port = "3306";
        private static string username = "root";
        private static string password = "";
        private static string database = "notes";

        // Подключение к БД
        private static MySqlConnection sqlConnection = new MySqlConnection("server=" + host + ";port=" + port + ";username=" + username + ";password=" + password + ";database=" + database + ";");
        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public MySqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}
