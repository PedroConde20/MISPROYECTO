using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Model;
using DAO.interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DAO.Implementation
{
    public class CategoryImpl : ICategory
    {
        public int Delete(Category t)
        {
            int res = 0;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Delete de la Tabla Category", DateTime.Now, Session.SessionID));
            string query = @"
                             UPDATE Category SET status=0
                              WHERE categoryID= @categoryID";

            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@categoryID", t.CategoryID);
                res = DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Delete Ejecutado Correctamente", DateTime.Now, Session.SessionID));

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Delete de la Tabla Category - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return res;
        }

        public Category Get(byte id)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Get de la Tabla Category", DateTime.Now, Session.SessionID));
            Category t = null;
            string query = @"SELECT categoryID ,categoryName ,categoryDescription , status , registerDate , lastUpdate , UserID
                               FROM Category
                               WHERE categoryID = @categoryID";
            SqlCommand command = null;
            SqlDataReader dr = null;
            try
            {
                command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@categoryID",id);
                dr= DataBase.ExecuteDataReaderCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Get Ejecutado Correctamente", DateTime.Now, Session.SessionID));
                while (dr.Read())
                {
                    t = new Category(byte.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), byte.Parse(dr[3].ToString()), DateTime.Parse(dr[4].ToString()), DateTime.Parse(dr[5].ToString()), short.Parse(dr[6].ToString()));
                }
            }
            catch (Exception ex )
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Get de la Tabla Category - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            finally
            {
                command.Connection.Close();
                dr.Close();
            }

            return t;
        }

        public int Insert(Category t)
        {
            int res = 0;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Insert de la Tabla Category", DateTime.Now, Session.SessionID));
            string query = @"INSERT INTO Category (categoryName, categoryDescription , lastUpdate , UserID)
                    VALUES (@categoryName, @categoryDescription, CURRENT_TIMESTAMP , @UserID)";

            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@categoryName", t.CategoryName);
                command.Parameters.AddWithValue("@categoryDescription", t.CategoryDescription);
                command.Parameters.AddWithValue("@UserID", t.UserID);
                res = DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Insert Ejecutado Correctamente", DateTime.Now, Session.SessionID));

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Insert de la Tabla Category - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return res;
        }

        public DataTable Selec()
        {
            DataTable dt = new DataTable();
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Select de la Tabla Category", DateTime.Now, Session.SessionID));
            string query = @"SELECT * FROM vwCategory
                                  ORDER BY 2";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                dt = DataBase.ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Select Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Select de la Tabla Category - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return dt;
        }


        public DataTable Selec2()
        {
            DataTable dt = new DataTable();
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Select de la Tabla Category", DateTime.Now, Session.SessionID));
            string query = @"SELECT * FROM vwCategory
                                  ORDER BY 2";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                dt = DataBase.ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Select Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Select de la Tabla Category - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return dt;
        }
        public DataTable SelectForanea()
        {
            DataTable dt = new DataTable();
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo SelectForanea de la Tabla Category", DateTime.Now, Session.SessionID));
            string query = @"SELECT categoryID, categoryName,categoryDescription
                                FROM Category
                                WHERE status=1
                                ORDER BY 2";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                dt = DataBase.ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo SelectForanea Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo SelectForanea de la Tabla Category - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return dt;
        }

        public DataTable SelectIDName()
        {
            DataTable dt = new DataTable();
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo SelectIDName de la Tabla Category", DateTime.Now, Session.SessionID));
            string query = @"SELECT categoryID, categoryName
                                FROM Category
                                WHERE status=1
                                ORDER BY 2";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                dt = DataBase.ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo SelectIDName Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo SelectIDName de la Tabla Category - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return dt;
        }

        public DataTable SelectLikeByName(string txt)
        {
            throw new NotImplementedException();
        }

        public int Update(Category t)
        {
            int res = 0;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Update de la Tabla Category", DateTime.Now, Session.SessionID));
            string query = @"UPDATE Category SET categoryName =@categoryName , categoryDescription = @categoryDescription,
					         lastUpdate=CURRENT_TIMESTAMP, UserID= @UserID
                             WHERE categoryID= @categoryID";

            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@categoryName" , t.CategoryName);
                command.Parameters.AddWithValue("@categoryDescription", t.CategoryDescription);
                command.Parameters.AddWithValue("@UserID", t.UserID);
                command.Parameters.AddWithValue("@categoryID", t.CategoryID);
                res= DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Update Ejecutado Correctamente", DateTime.Now, Session.SessionID));

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Update de la Tabla Category - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return res;
        }
    }
}
