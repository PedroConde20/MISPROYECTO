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
    public class UserImpl : IUser
    {
        public int Delete(User t)
        {
            int res = 0;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Delete de la Tabla Users", DateTime.Now, Session.SessionID));
            string query = @"UPDATE [User] SET status=0
                             WHERE UserID = @UserID";

            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@UserID", t.UserID);
                res = DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Delete Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Delete de la Tabla Users - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return res;
        }

        public User Get(byte id)
        {
            User t = null;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Get de la Tabla Users", DateTime.Now, Session.SessionID));
            string query = @"SELECT UserID,role,userName,password,status,registerDate,lastUpdate,registerUser,UserFirstName,
                             UserLastName,UserEmail,UserCI,NewUser
                             FROM [User]
                             WHERE UserID = @UserID"; 
            SqlCommand command = null;
            SqlDataReader dr = null;

            try
            {
                command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@UserID", id);
                dr = DataBase.ExecuteDataReaderCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Get Ejecutado Correctamente", DateTime.Now, Session.SessionID));
                while (dr.Read())
                {
                    t = new User(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), byte.Parse(dr[3].ToString()), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(),byte.Parse(dr[8].ToString()), short.Parse(dr[9].ToString()), DateTime.Parse(dr[10].ToString()), DateTime.Parse(dr[11].ToString()), byte.Parse(dr[12].ToString()), int.Parse(dr[13].ToString()));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Get de la Tabla Users - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            finally
            {
                command.Connection.Close();
                dr.Close();
            }

            return t;
        }

        public int SaveId()
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(DataBase.GetIdTable("User"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }
        public int Insert(User t)
        {
            int res = 0;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Insert de la Tabla Users", DateTime.Now, Session.SessionID));
            string query = @"INSERT INTO [User](role,UserFirstName,UserLastName,UserCI,UserEmail,userName,password,lastUpdate,registerUser,image)
                             VALUES(@role,@UserFirstName,@UserLastName,@UserCI,@UserEmail,@username,
                             HASHBYTES('md5',@password),CURRENT_TIMESTAMP,@registerUser,@image)";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@role", t.Role);
                command.Parameters.AddWithValue("@UserFirstName", t.UserFirstName);
                command.Parameters.AddWithValue("@UserLastName", t.UserLastName);
                command.Parameters.AddWithValue("@UserCI", t.UserCI);
                command.Parameters.AddWithValue("@UserEmail", t.UserEmail);
                command.Parameters.AddWithValue("@username", t.UserName);
                command.Parameters.AddWithValue("@password", t.Password).SqlDbType = SqlDbType.VarChar;
                command.Parameters.AddWithValue("@UserID", t.UserID);
                command.Parameters.AddWithValue("@registerUser", t.RegisterUserID);
                command.Parameters.AddWithValue("@image", t.Image);
                res = DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Insert Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Insert de la Tabla Users - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return res;
        }

        public int ChangePassword(short id , string newPassword)
        {
            //Primer Acceso se activa esto
            string query = @"UPDATE [User] SET password = HASHBYTES('md5', @password), NewUser = 1
							WHERE UserID = @userID";
            int res = 0;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo ChangePassword de la Tabla Users", DateTime.Now, Session.SessionID));
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@userID", id);
                command.Parameters.AddWithValue("@password", newPassword).SqlDbType = SqlDbType.VarChar;
                res = DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo ChangePassword Ejecutado", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo ChangePassword de la Tabla Users - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return res;
        }
        public int ChangePassAlready(short id, string newPassword)
        {
            //Cambio de Contraseña del propio usuario
            string query = @"UPDATE [User] SET password = HASHBYTES('md5', @password)
							WHERE UserID = @userID";
            int res = 0;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo ChangePassAlready de la Tabla Users", DateTime.Now, Session.SessionID));
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@userID", id);
                command.Parameters.AddWithValue("@password", newPassword).SqlDbType = SqlDbType.VarChar;
                res = DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo ChangePassAlready Ejecutado", DateTime.Now, Session.SessionID));

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo ChangePassAlready de la Tabla Users - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return res;
        }
        #region OlvidarPassword
        public int AdminChangePass(short id, string newPassword, string emailagain)
        {
            //Administrador cambia tu contraseña y vuelve vuelve a 0 a tu NewUser
            string query = @"UPDATE [User] SET password = HASHBYTES('md5', @password),UserEmail = @UserEmail ,NewUser = 0
							WHERE UserID = @UserID";
            int res = 0;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo AdminChangePass de la Tabla Users", DateTime.Now, Session.SessionID));
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@UserID", id);
                command.Parameters.AddWithValue("@password", newPassword).SqlDbType = SqlDbType.VarChar;
                command.Parameters.AddWithValue("@UserEmail", emailagain);
                res = DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo AdminChangePass Ejecutado", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo AdminChangePass de la Tabla Users - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return res;
        }
        public DataTable SelecAdmin()
        {
            DataTable dt = new DataTable();
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo SelecAdmin de la Tabla Users", DateTime.Now, Session.SessionID));
            string query = @"SELECT * FROM vwUser";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                dt = DataBase.ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo SelectAdmin Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo SelecAdmin de la Tabla Users - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return dt;
        }
        public User GetAdmin(byte id)
        {
            User t = null;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo GetAdmin de la Tabla Users", DateTime.Now, Session.SessionID));

            string query = @"SELECT registerUser , userName, password , role,UserFirstName,UserLastName,UserEmail,UserCI
	                                 ,NewUser, UserID,registerDate,lastUpdate,status
	                                 FROM [User]
                                     WHERE UserID = @UserID";
            SqlCommand command = null;
            SqlDataReader dr = null;
            try
            {
                command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@UserID", id);
                dr = DataBase.ExecuteDataReaderCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo GetAdmin Ejecutado Correctamente", DateTime.Now, Session.SessionID));
                while (dr.Read())
                {
                    t = new User(byte.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(),dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), byte.Parse(dr[8].ToString()), short.Parse(dr[9].ToString()), DateTime.Parse(dr[10].ToString()), DateTime.Parse(dr[11].ToString()), byte.Parse(dr[12].ToString()), int.Parse(dr[13].ToString()));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo GetAdmin de la Tabla Users - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            finally
            {
                command.Connection.Close();
                dr.Close();
            }

            return t;
        }
        #endregion

        public DataTable Login(string userName, string password)
        {
            DataTable dt = new DataTable();
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Login de la Tabla Users", DateTime.Now, Session.SessionID));
            string query = @"SELECT UserID ,userName,role,NewUser
                                FROM [User]
                                WHERE status = 1 AND userName= @userName AND password=HASHBYTES('md5',@password)";
            try
            {
 
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@userName", userName);//HAGARRAMOS EL USER 
                command.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;//HAGARRAMOS EL PASSWORD

                dt = DataBase.ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Login Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Login de la Tabla Users - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return dt;
        }


        public DataTable Selec()
        {
            DataTable dt = new DataTable();
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Select de la Tabla Users", DateTime.Now, Session.SessionID));
            string query = @"SELECT * FROM vwUser";
            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                dt = DataBase.ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Select Ejecutado Correctamente", DateTime.Now, Session.SessionID));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Select de la Tabla Users - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return dt;
        }
        public DataTable SelectLikeByName(string txt)
        {
            throw new NotImplementedException();
        }

        public int Update(User t)
        {
            int res = 0;
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Update de la Tabla Users", DateTime.Now, Session.SessionID));
            string query = @"UPDATE [User] SET role =@role , userName = @userName, password = @password, lastUpdate = CURRENT_TIMESTAMP
				                     , UserFirstName=@UserFirstName,UserLastName=@UserLastName
				                     ,UserEmail =@UserEmail , UserCI =@UserCI ,
				                     WHERE UserID = @UserID";

            try
            {
                SqlCommand command = DataBase.CreateBasicCommand(query);
                command.Parameters.AddWithValue("@role", t.Role);
                command.Parameters.AddWithValue("@userName", t.UserName);
                command.Parameters.AddWithValue("@password", t.Password);
                command.Parameters.AddWithValue("@UserFirstName", t.UserFirstName);
                command.Parameters.AddWithValue("@UserLastName", t.UserLastName);
                command.Parameters.AddWithValue("@UserEmail", t.UserEmail);
                command.Parameters.AddWithValue("@UserCI", t.UserCI);
                command.Parameters.AddWithValue("@UserID", t.UserID);
                res =  DataBase.ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Update Ejecutado Correctamente", DateTime.Now, Session.SessionID));

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Update de la Tabla Users - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
                throw ex;
            }
            return res;
        }

        public DataTable SelectLikeByRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
