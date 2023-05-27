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
    public class ProductImpl : IProduct
    {
        public int Delete(Product t)
        {
            int res = 0;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Delete de la Tabla ProductImpl", DateTime.Now, Session.SessionID));
            string query = @"UPDATE ProductList SET image=0, status=0,lastUpdate= CURRENT_TIMESTAMP
                            WHERE productID =@wineID";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@wineID", t.ProductID);
                res = DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Metodo Delete Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Delete de la Tabla ProductImpl - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return res;
        }

        public DataTable Find(Product wine)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            Product t = null;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Get de la Tabla ProductImpl", DateTime.Now, Session.SessionID));
            string query = @"SELECT productID, productName, price, [Image] , stock , descriptionProduct,categoryID,status,registerDate,
                            lastUpdate, UserID, supplierID
                            FROM ProductList
                            WHERE productID =@wineID";

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
                    t = new Product(byte.Parse(dr[0].ToString()), dr[1].ToString(), double.Parse(dr[2].ToString()), int.Parse(dr[3].ToString()), int.Parse(dr[4].ToString()), dr[5].ToString(), byte.Parse(dr[6].ToString()), byte.Parse(dr[7].ToString()), DateTime.Parse(dr[8].ToString()), DateTime.Parse(dr[9].ToString()), short.Parse(dr[10].ToString()), byte.Parse(dr[11].ToString()));
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
        public int Insert(Product t)
        {
            int res = 0;
            string query = @"INSERT INTO ProductList(categoryID,productName,price,[image],stock,descriptionProduct,lastUpdate,UserID, supplierID)
                            VALUES (@categoryID,@productName,@price,@image,@stock,@descriptionProduct,CURRENT_TIMESTAMP,@UserID,@supplierID)";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@categoryID", t.CategoryID);
                command.Parameters.AddWithValue("@productName", t.ProductName);
                command.Parameters.AddWithValue("@price", t.Price);
                command.Parameters.AddWithValue("@image", t.Image);
                command.Parameters.AddWithValue("@stock", t.Stock);
                command.Parameters.AddWithValue("@descriptionProduct", t.DescriptionProduct);
                command.Parameters.AddWithValue("@UserID", t.UserID);
                command.Parameters.AddWithValue("@supplierID", t.SupplierID);
                res = DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Insert Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Insert de la Tabla Product - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return res;
        }
        public int SaveId()
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(DataBase.GetIdTable("ProductList"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }

        public DataTable Selec()
        {
            DataTable dt = new DataTable();
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Select de la Tabla ProductImpl", DateTime.Now, Session.SessionID));
            string query = @"SELECT * FROM vwProduct
                                 ORDER BY 2";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                dt = DataBase.ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Select Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Select de la Tabla ProductImpl - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return dt;
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
                command.Parameters.AddWithValue("@txt", "%"+ txt +"%");
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

        public int Update(Product t)
        {
            int res = 0;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Update de la Tabla Wine Update", DateTime.Now, Session.SessionID));
            string query = @"UPDATE ProductList SET categoryID = @categoryID, productName = @productName , price = @price, [image] =1 , stock = @stock,
					        descriptionProduct= @descriptionProduct, lastUpdate = CURRENT_TIMESTAMP,
                            UserID = @UserID, supplierID = @supplierID
					        WHERE productID = @wineID";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@categoryID", t.CategoryID);
                command.Parameters.AddWithValue("@productName", t.ProductName);
                command.Parameters.AddWithValue("@price", t.Price);
                //imagen
                command.Parameters.AddWithValue("@stock", t.Stock);
                command.Parameters.AddWithValue("@descriptionProduct", t.DescriptionProduct);
                command.Parameters.AddWithValue("@UserID", t.UserID);
                command.Parameters.AddWithValue("@supplierID", t.SupplierID);
                command.Parameters.AddWithValue("@wineID", t.ProductID);

                res = DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Update Ejecutado Correctamente", DateTime.Now, Session.SessionID));

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Update de la Tabla ProductImpl - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
            }
            return res;
        }
      
    }
}
