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
            throw new NotImplementedException();
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

        public DataTable SelectLikeByName(string txt)
        {
            throw new NotImplementedException();
        }

        public int Update(PublicStore t)
        {
            throw new NotImplementedException();
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
    }
}
