using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.interfaces;
using DAO.Model;

namespace DAO.Implementation
{
    public class ProductStoreImpl : IPublicStore
    {
        public int Delete(PublicStore t)
        {
            throw new NotImplementedException();
        }

        public DataTable Find(PublicStore product)
        {
            throw new NotImplementedException();
        }

        public PublicStore Get(int id)
        {
            PublicStore t = null;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Get de la Tabla ProductImpl", DateTime.Now, Session.SessionID));
            string query = @"SELECT P.PublicStoreID, P.productName, P.price, P.[Image] , P.stock , P.descriptionProduct,C.categoryID,P.status,P.registerDate,
                            P.lastUpdate, P.UserID, PL.productID
                            FROM PublicStore P
							INNER JOIN ProductList PL ON PL.productID = P.PublicStoreID
							INNER JOIN Category C ON C.categoryID = PL.categoryID
                            WHERE P.PublicStoreID =@wineID";

            SqlCommand command = null;
            SqlDataReader dr = null;
            try
            {
                command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@wineID", id);
                dr = DataBase.ExecuteDataReaderCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Get Ejecutado Correctamente", DateTime.Now, Session.SessionID));
                while (dr.Read())
                {
                    t = new PublicStore(byte.Parse(dr[0].ToString()), dr[1].ToString(), double.Parse(dr[2].ToString()), int.Parse(dr[3].ToString()), int.Parse(dr[4].ToString()), dr[5].ToString(), byte.Parse(dr[6].ToString()), byte.Parse(dr[7].ToString()), DateTime.Parse(dr[8].ToString()), DateTime.Parse(dr[9].ToString()), short.Parse(dr[10].ToString()), byte.Parse(dr[11].ToString()));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Get de la Tabla ProductImpl - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            finally
            {
                command.Connection.Close();
                dr.Close();
            }
            return t;
        }

        public int Insert(PublicStore t)
        {
            throw new NotImplementedException();
        }

        public int SaveId()
        {
            throw new NotImplementedException();
        }

        public DataTable Selec()
        {
            throw new NotImplementedException();
        } 

        public int Update(PublicStore t)
        {
            int res = 0;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Update de la Tabla Wine Update", DateTime.Now, Session.SessionID));
            string query = @"UPDATE PublicStore SET  stock = @stock, lastUpdate = CURRENT_TIMESTAMP,                         
					        WHERE PublicStoreID = @wineID";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@stock", t.Stock);
                command.Parameters.AddWithValue("@wineID", t.publicStoreID);

                res = DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Update Ejecutado Correctamente", DateTime.Now, Session.SessionID));

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Update de la Tabla ProductImpl - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
            }
            return res;
        }

        public int UpdateStockProduct(int stock, int productoId)
        {
            int res = 0;
            string query = @"UPDATE ProductList
                            SET stock = stock - @stock
                            WHERE productID = @productID";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@stock", stock);
                command.Parameters.AddWithValue("@productID", productoId);


                res = DataBase.ExecuteBasicCommand(command);

            }
            catch (Exception ex)
            {
            }
            return res;
        }
        public int UpdateStockProductStore(int stock, int productoId)
        {
            int res = 0;
            string query = @"UPDATE PublicStore
                            SET stock = stock + @stock
                            WHERE productID = @productID";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@stock", stock);
                command.Parameters.AddWithValue("@productID", productoId);
    

                res = DataBase.ExecuteBasicCommand(command);

            }
            catch (Exception ex)
            {
            }
            return res;
        }


        public DataTable SelectProducts()
        {
            DataTable dt = new DataTable();
            string query = @" SELECT productID, productName FROM ProductList";
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

        public Product GetjustStock(int id)
        {
            Product t = null;
            string query = @" SELECT stock FROM ProductList WHERE productID = @productid";
            SqlCommand command = null;
            SqlDataReader dr = null;
            try
            {
                command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@productid", id);
                dr = DataBase.ExecuteDataReaderCommand(command);
                while (dr.Read())
                {
                    t = new Product(byte.Parse(dr[0].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
                dr.Close();
            }

            return t;
        }

        public DataTable SelectLikeByName(string txt)
        {
            DataTable dt = new DataTable();
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo SelectLikeByName de la Tabla ProductImpl", DateTime.Now, Session.SessionID));
            string query = @"SELECT P.productID, CONCAT(P.productName, '-', C.categoryName) AS Producto, P.price
                                FROM ProductList P
                                INNER JOIN Category C ON C.categoryID = P.categoryID
                                WHERE P.status=1 AND (CONCAT(P.productName, '-', C.categoryName) LIKE @txt)";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@txt", "%" + txt + "%");
                dt = DataBase.ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo SelectLikeByName Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo SelectLikeByName de la Tabla ProductImpl - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return dt;
        }
    }

}
