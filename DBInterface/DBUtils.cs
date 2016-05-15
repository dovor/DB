using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace DBInterface
{
    class DBUtils
    {
        private static SqlConnection connection;

        public static string error = ""; //TODO: delete;

        public static bool init(string login, string password)
        {
            connection = new SqlConnection(String.Format("Data Source=DESKTOP-DMNDCCV\\SQLEXPRESS;Initial Catalog=rest;Integrated Security=SSPI;User ID={0};Password={1}", login, password));
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                return false;
            } finally
            {
                connection.Close();
            }
            return true;
        }

        public static bool init()
        {
            connection = new SqlConnection(String.Format("Data Source=DESKTOP-DMNDCCV\\SQLEXPRESS;Initial Catalog=rest;Integrated Security=SSPI;User ID=admin;Password=admin"));
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public static bool executeCommand(string cmd_name, Dictionary<string, object> cmd_params)
        {
            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = cmd_name;
            foreach (KeyValuePair<string, object> entry in cmd_params)
            {
                cmd.Parameters.AddWithValue(entry.Key, entry.Value);
            }

            int count;
            try
            {
                connection.Open();
                count = cmd.ExecuteNonQuery();
            } catch (Exception e)
            {
                error = e.ToString();
                return false;
            } finally
            {
                connection.Close();
            }

            if (count == 0) return false; else return true;
        }
    }
}
