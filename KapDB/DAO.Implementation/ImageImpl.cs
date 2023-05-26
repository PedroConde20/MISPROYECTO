using DAO.interfaces;
using DAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO.Implementation
{
    class ImageImpl : IImage
    {
        public int Delete(Image t)
        {
            throw new NotImplementedException();
        }

        public int Insert(Image t)
        {
            throw new NotImplementedException();
        }

        //public Image InsertImage(string nombre, PictureBox image)
        //{
        //    int res = 0;
        //    System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Inicializando el Metodo Insert de la Tabla Client", DateTime.Now, Session.SessionID));
        //    string query = @"INSERT INTO [Image] (imagenName,img) VALUES (@imagenName,@img)";
        //    try
        //    {
        //        SqlCommand command = DataBase.CreateBasicCommand(query);
        //        command.Parameters.Add("@imagenName", SqlDbType.NVarChar);
        //        command.Parameters.Add("@img", SqlDbType.Image);


        //        command.Parameters["@imagenName"].Value = nombre;
        //        res = DataBase.ExecuteBasicCommand(command);
        //        System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1}  Metodo Insert Ejecutado Correctamente", DateTime.Now, Session.SessionID));

        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(string.Format("{0} - User: {1} Error en el metodo Insert de la Tabla Client - {2} - {3}", DateTime.Now, Session.SessionID, ex.Message, query));
        //        throw ex;
        //    }
        //    return res;
        //}

        public DataTable Selec()
        {
            throw new NotImplementedException();
        }

        public int Update(Image t)
        {
            throw new NotImplementedException();
        }
    }
}
