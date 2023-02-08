using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thong_Tin_Khach_hang
{
    internal class dataProvider
    {
        private static dataProvider instance;
        private string connectionStr => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public SqlConnection getConnection()
        {
            return new SqlConnection(connectionStr);
        }
        public static dataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new dataProvider();
                return dataProvider.instance;
            }
            private set
            {
                dataProvider.instance = value;
            }
        }
        private dataProvider() { }
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    try
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (var item in listPara)
                        {
                            if (item.Contains('@'))
                            {

                                command.Parameters.AddWithValue(item, parameter[i].ToString());
                                i++;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: " + e);
                        Console.WriteLine(e.StackTrace);
                    }
                }
                data = command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Close();
            }
            return data;
        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    try
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (var item in listPara)
                        {
                            if (item.Contains('@'))
                            {

                                command.Parameters.AddWithValue(item, parameter[i].ToString());
                                i++;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: " + e);
                        Console.WriteLine(e.StackTrace);
                    }
                }
                data = command.ExecuteScalar();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Close();
            }
            return data;
        }
        public bool ExecuteReader(string query, object[] parameter = null)
        {
            bool result = false;
            SqlDataReader dataReader;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                dataReader = command.ExecuteReader();
                result=  dataReader.Read();
                connection.Close();
            }
            return result;
        }
    }
}
