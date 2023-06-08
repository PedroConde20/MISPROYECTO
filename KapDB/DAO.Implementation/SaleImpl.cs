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
    public class SaleImpl : ISale
    {
        public int Delete(Sale t)
        {
            throw new NotImplementedException();
        }

        public void Insert(Sale t, List<SaleDetail> d)
        {

            List<SqlCommand> commands = new List<SqlCommand>();
            //Aqui hacemos el Insert
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Insert de la Tabla SaleImpl", DateTime.Now, Session.SessionID));
            string querySale = @"INSERT INTO Sale (fechaVenta, total , clientID,lastUpdate,UserID)
                            VALUES (@fechaVenta, @total , @clientID,CURRENT_TIMESTAMP,@UserID)";

            string queryDetail = @"INSERT INTO SaleDetail (saleID, PublicStoreID , quantiy,price)
                                    VALUES  (@saleID, @productID , @quantiy,@price) ";
            try
            {
                commands = DataBase.CreateNBasicCommand(1+d.Count);

                int id = int.Parse(DataBase.GetIdTable("Sale"));

                for (int i = 0; i < commands.Count; i++)
                {
                    if (i==0)
                    {
                        commands[i].CommandText = querySale;
                        commands[i].Parameters.AddWithValue("@fechaVenta", t.FechaVenta);
                        commands[i].Parameters.AddWithValue("@total", t.Total);
                        commands[i].Parameters.AddWithValue("@clientID", t.ClientID);
                        commands[i].Parameters.AddWithValue("@UserID",Session.SessionID);
                    }
                    else
                    {
                        commands[i].CommandText = queryDetail;
                        commands[i].Parameters.AddWithValue("@saleID",id);
                        commands[i].Parameters.AddWithValue("@productID", d[i-1].WineID);
                        commands[i].Parameters.AddWithValue("@quantiy",d[i-1].Quantiy);
                        commands[i].Parameters.AddWithValue("@price",d[i-1].Price);
                    }
                }
                DataBase.ExecuteNBasicCommand(commands);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Insert-Order Ejecutado Correctamente", DateTime.Now, Session.SessionID));

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Insert de la Tabla SaleImpl - {2} ", DateTime.Now, Session.SessionID, ex.Message));
                throw ex;
            }
        }
        public int SaveId()
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(DataBase.GetIdTable("Sale"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }
        public int Insert(Sale t)
        {
            throw new NotImplementedException();
        }

        public DataTable Selec()
        {
            throw new NotImplementedException();
        }

        public int Update(Sale t)
        {
            throw new NotImplementedException();
        }
    }
}
