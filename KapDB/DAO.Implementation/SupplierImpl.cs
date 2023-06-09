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
    public class SupplierImpl : ISupplier

    {
        public int Delete(Supplier t)
        {
            int res = 0;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Delete de la Tabla Supplier", DateTime.Now, Session.SessionID));
            string query = @"UPDATE Supplier SET status=0
                             WHERE supplierID = @supplierID";

            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@supplierID", t.SupplierID);
                res = DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Delete Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Delete de la Tabla Supplier - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return res;
        }


        public Supplier Get(byte id)
        {
            Supplier t = null;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Get de la Tabla Supplier", DateTime.Now, Session.SessionID));
            string query = @"SELECT supplierID,supplierName,supplierLastName,supplierCI,direction,cellphone,email,UserID,registerDate
		                    ,lastUpdate,status
                            FROM Supplier
                            WHERE supplierID = @supplierID
";
            SqlCommand command = null;
            SqlDataReader dr = null;
            try
            {
                command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@supplierID", id);
                dr = DataBase.ExecuteDataReaderCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Get Ejecutado Correctamente", DateTime.Now, Session.SessionID));
                while (dr.Read())
                {
                    t = new Supplier(byte.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), short.Parse(dr[7].ToString()), DateTime.Parse(dr[8].ToString()), DateTime.Parse(dr[9].ToString()), byte.Parse(dr[10].ToString()));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Get de la Tabla Supplier - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            finally
            {
                command.Connection.Close();
                dr.Close();
            }

            return t;
        }

        public DataTable SelectProveedores()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT supplierID, CONCAT(supplierName, ' ' ,supplierLastname) AS 'nombrecompleto' FROM Supplier";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                dt = DataBase.ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable Selec()
        {
            DataTable dt = new DataTable();
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Select de la Tabla Supplier", DateTime.Now, Session.SessionID));
            string query = @"SELECT * FROM Supplier
                                WHERE status = 1
                                ORDER BY 2 ";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                dt = DataBase.ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Select Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Select de la Tabla Supplier - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return dt;
        }
        public int Insert(Supplier t)
        {
            int res = 0;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Insert de la Tabla Supplier", DateTime.Now, Session.SessionID));
            string query = @"INSERT INTO Supplier (supplierName, supplierLastName, supplierCI,direction,
					cellphone,email,UserID,lastUpdate)
                            VALUES (@supplierName,@supplierLastName,@supplierCI,@direction,
					@cellphone,@email,@UserID,CURRENT_TIMESTAMP)";

            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@supplierName", t.SupplierName);
                command.Parameters.AddWithValue("@supplierLastName", t.SupplierLastName);
                command.Parameters.AddWithValue("@supplierCI", t.SupplierCI);
                command.Parameters.AddWithValue("@direction", t.SupplierDirection);
                command.Parameters.AddWithValue("@cellphone", t.SupplierCellphone);
                command.Parameters.AddWithValue("@email", t.SupplierEmail);
                command.Parameters.AddWithValue("@UserID", t.UserID);
                res = DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Insert Ejecutado Correctamente", DateTime.Now, Session.SessionID));

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Insert de la Tabla Supplier - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return res;
        }

        public DataTable selectOneSupplier(int id)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT productID, productName AS 'Nombre Producto', descriptionProduct AS 'Descripcion', C.categoryName AS 'Categoria'
                            FROM productList PL
                            INNER JOIN Category C ON C.categoryID = Pl.categoryID
                            WHERE PL.supplierID = @supplierID;";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@supplierID", id);
                dt = DataBase.ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectLikeByName(string txt)
        {//No usado pero funcional
            DataTable dt = new DataTable();
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo SelectLikeByName de la Tabla Supplier", DateTime.Now, Session.SessionID));
            string query = @"SELECT C.supplierID,C.supplierCI, CONCAT(C.supplierLastName,' ',C.supplierName) AS 'Nombre Completo'
                            FROM Supplier S
                            WHERE (C.supplierCI LIKE @txt OR CONCAT(C.supplierLastName,' ',C.supplierName) LIKE @txt)";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@txt", "%" + txt + "%");
                dt = DataBase.ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo SelectLikeByName Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo SelectLikeByName de la Tabla Supplier - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return dt;
        }

        public int Update(Supplier t)
        {
            int res = 0;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Update de la Tabla Supplier", DateTime.Now, Session.SessionID));
            string query = @"UPDATE Supplier SET supplierName=@supplierName, supplierLastName=@supplierLastName, supplierCI=@supplierCI,
				              direction=@direction,cellphone=@cellphone ,email=@email,
				              UserID=@UserID, lastUpdate = CURRENT_TIMESTAMP
				              WHERE supplierID=@supplierID";

            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@supplierName", t.SupplierName);
                command.Parameters.AddWithValue("@supplierLastName", t.SupplierLastName);
                command.Parameters.AddWithValue("@supplierCI", t.SupplierCI);
                command.Parameters.AddWithValue("@direction", t.SupplierDirection);
                command.Parameters.AddWithValue("@cellphone", t.SupplierCellphone);
                command.Parameters.AddWithValue("@email", t.SupplierEmail);
                command.Parameters.AddWithValue("@UserID", t.UserID);
                command.Parameters.AddWithValue("@supplierID", t.SupplierID);
                res = DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Update Ejecutado Correctamente", DateTime.Now, Session.SessionID));

            }
            catch (Exception ex)
            {
                //Logs de errores!
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Update de la Tabla Supplier - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
            }
            return res;
        }
        public DataTable SelectProveedor()
        {
            DataTable dt = new DataTable();
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo SelectForanea de la Tabla Category", DateTime.Now, Session.SessionID));
            string query = @"SELECT supplierID, supplierName,supplierLastname
                                FROM Supplier
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
    }
}
