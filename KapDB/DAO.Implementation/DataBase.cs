using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Implementation
{
    public class DataBase
    {
        static string connectionString = "Data Source = LAPTOP-COU1EKKM\\SQLEXPRESS; Initial Catalog = DBBKap;User ID=sa; Password = Univalle2021; Integrated Security = True";

        public static SqlCommand CreateBasicCommand()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            return command;
        }

        public static SqlCommand CreateBasicCommand( string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query);
            command.Connection = connection;
            return command;
        }


        /// <summary>
        /// INSERT UPDATE DELETE
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static int ExecuteBasicCommand(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex )
            {

                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }


        /// <summary>
        /// SELECTS
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTableCommand(SqlCommand command)
        {
            DataTable res = new DataTable();
            try
            {
                command.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(res);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
            return res;
        }

        /// <summary>
        /// get
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteDataReaderCommand(SqlCommand command)
        {
            SqlDataReader dr = null;
            try
            {
                command.Connection.Open();
                 dr= command.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dr;
        }




        //Para Imagenes 
        public static string GetIdTable(string value)
        {
            //tipo de consulta
            string query = @"SELECT IDENT_CURRENT('" + value + "') + IDENT_INCR('" + value + "')";

            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand();
            command = CreateBasicCommand(query);
            try
            {
                command.Connection.Open();

                return command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }


        public static void ExecuteNBasicCommand(List<SqlCommand> commands)
        {
            SqlTransaction transaction = null;
            SqlCommand command1 = commands[0];
            try
            {
                command1.Connection.Open();
                transaction = command1.Connection.BeginTransaction();
                foreach (SqlCommand item in commands)
                {
                    item.Transaction = transaction;
                    item.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                command1.Connection.Close();
            }
        }

        public static List<SqlCommand> CreateNBasicCommand(int n)
        {
            List<SqlCommand> res = new List<SqlCommand>();
            SqlConnection connection = new SqlConnection(connectionString);

            for (int i = 0; i < n; i++)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                res.Add(command);
            }
            return res;
        }

    }
}
