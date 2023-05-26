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
    public class ClienteImpl : IClient
    {
        public int Delete(Client t)
        {
            int res = 0;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Delete de la Tabla Client", DateTime.Now, Session.SessionID));
            string query = @"UPDATE client SET status=0
                             WHERE clientID = @clientID";

            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@clientID", t.ClientID);
                res =  DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Delete Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Delete de la Tabla Client - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return res;
        }

        public Client Get(byte id)
        {
            Client t = null;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Get de la Tabla Client", DateTime.Now, Session.SessionID));
            string query = @"SELECT clientID,clientName,clientLastName,clientCI,direction,telephone,email,UserID,registerDate
		                    ,lastUpdate,status
                            FROM client
                            WHERE clientID = @clientID
";
            SqlCommand command = null;
            SqlDataReader dr = null;
            try
            {
                command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@clientID", id);
                dr = DataBase.ExecuteDataReaderCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Get Ejecutado Correctamente", DateTime.Now, Session.SessionID));
                while (dr.Read())
                {
                    t = new Client(byte.Parse(dr[0].ToString()), dr[1].ToString(),dr[2].ToString(),dr[3].ToString(),dr[4].ToString(),dr[5].ToString(), dr[6].ToString(),short.Parse(dr[7].ToString()), DateTime.Parse(dr[8].ToString()), DateTime.Parse(dr[9].ToString()), byte.Parse(dr[10].ToString()));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Get de la Tabla Client - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            finally
            {
                command.Connection.Close();
                dr.Close();
            }

            return t;
        }

        public int Insert(Client t)
        {
            int res = 0;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Insert de la Tabla Client", DateTime.Now, Session.SessionID));
            string query = @"INSERT INTO client (clientName, clientLastName, clientCI,direction,
					telephone,email,UserID,lastUpdate)
                            VALUES (@clientName,@clientLastName,@clientCI,@direction,
					@telephone,@email,@UserID,CURRENT_TIMESTAMP)";

            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@clientName", t.ClientName);
                command.Parameters.AddWithValue("@clientLastName", t.ClientLastName);
                command.Parameters.AddWithValue("@clientCI", t.ClientCI);
                command.Parameters.AddWithValue("@direction", t.ClientDirection);
                command.Parameters.AddWithValue("@telephone", t.ClientTelephone);
                command.Parameters.AddWithValue("@email", t.ClientEmail);
                command.Parameters.AddWithValue("@UserID", t.UserID);
                res =  DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Insert Ejecutado Correctamente", DateTime.Now, Session.SessionID));

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Insert de la Tabla Client - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return res;
        }

        public DataTable Selec()
        {
            DataTable dt = new DataTable();
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Select de la Tabla Client", DateTime.Now, Session.SessionID));
            string query = @"SELECT * FROM vwclient
                                 ORDER BY 2";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                dt = DataBase.ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Select Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Select de la Tabla Client - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return dt;
        }

        public DataTable SelectIDDescription()
        {
            DataTable dt = new DataTable();
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo SelectIDDescription de la Tabla Client", DateTime.Now, Session.SessionID));
            string query = @"SELECT clientID, CONCAT(clientName, ' - CI: ', clientCI) AS Client	
                                FROM Client
                                WHERE status =1";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                dt = DataBase.ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo SelectIDDescription Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo SelectIDDescription de la Tabla Client - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return dt;
        }

        public DataTable SelectLikeByName(string txt)
        {//No usado pero funcional
            DataTable dt = new DataTable();
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo SelectLikeByName de la Tabla Client", DateTime.Now, Session.SessionID));
            string query = @"SELECT C.clientID,C.clientCI, CONCAT(C.clientLastName,' ',C.clientName) AS 'Nombre Completo'
                            FROM Client C
                            WHERE (C.clientCI LIKE @txt OR CONCAT(C.clientLastName,' ',C.clientName) LIKE @txt)";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@txt", "%"+txt+"%");
                dt = DataBase.ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo SelectLikeByName Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo SelectLikeByName de la Tabla Client - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return dt;
        }

        public int Update(Client t)
        {
            int res = 0;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Update de la Tabla Client", DateTime.Now, Session.SessionID));
            string query = @"UPDATE client SET clientName=@clientName, clientLastName=@clientLastName, clientCI=@clientCI,
				              direction=@direction,telephone=@telephone ,email=@email,
				              UserID=@UserID, lastUpdate = CURRENT_TIMESTAMP
				              WHERE clientID=@clientID";

            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@clientName", t.ClientName);
                command.Parameters.AddWithValue("@clientLastName", t.ClientLastName);
                command.Parameters.AddWithValue("@clientCI", t.ClientCI);
                command.Parameters.AddWithValue("@direction", t.ClientDirection);
                command.Parameters.AddWithValue("@telephone", t.ClientTelephone);
                command.Parameters.AddWithValue("@email", t.ClientEmail);
                command.Parameters.AddWithValue("@UserID", t.UserID);
                command.Parameters.AddWithValue("@clientID", t.ClientID);
                res= DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Update Ejecutado Correctamente", DateTime.Now, Session.SessionID));

            }
            catch (Exception ex)
            {
                //Logs de errores!
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Update de la Tabla Client - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
            }
            return res;
        }
    }
}
