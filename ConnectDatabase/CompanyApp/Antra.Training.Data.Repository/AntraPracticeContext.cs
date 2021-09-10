using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
namespace Antra.Training.Data.Repository
{
    class AntraPracticeContext
    {
        public string ConnectionString
        {
            get
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
                return builder.GetConnectionString("AntraPracticeDevDB");
            }
        }
        public int Execute(string command, Dictionary<string, object> parameters, CommandType cmdType = CommandType.Text)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = command;
                cmd.CommandType = cmdType;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }

                cmd.Connection = conn;
                int res = cmd.ExecuteNonQuery();
                conn.Close();
                //conn.Dispose();
                //cmd.Dispose();
                return res;
            }

        }
        public DataTable Query(string command, Dictionary<string, object> parameters, CommandType cmdType = CommandType.Text)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn.Open();
                cmd.CommandText = command;
                cmd.CommandType = cmdType;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                cmd.Connection = conn;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }
            return null;
        }
    }
}
