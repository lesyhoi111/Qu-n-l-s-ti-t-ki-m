using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ConnectDB
{
    internal class DataProvider
    {//@"Data Source=(local);Initial Catalog=QLSTK;User ID=sa;Password=30012002;Integrated Security=True"
        private string connectionSTR = @"Data Source=DESKTOP-58Q99IV\SQLEXPRESS;Initial Catalog=QLSTK;Integrated Security=True";
        public DataTable ExcuteQuery(string query)
        {
            SqlConnection connection = new SqlConnection(connectionSTR);

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            DataTable data = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(data);
            connection.Close();
            return data;
        }
    }
}
