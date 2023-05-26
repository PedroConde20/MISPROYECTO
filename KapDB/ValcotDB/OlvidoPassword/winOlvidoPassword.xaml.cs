using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DAO.Model;
using DAO.Implementation;
using System.Data;

namespace KapDB.OlvidoPassword
{
    /// <summary>
    /// Lógica de interacción para winOlvidoPassword.xaml
    /// </summary>
    public partial class winOlvidoPassword : Window
    {
        UserImpl implUser;
        User user;
        sbyte option = -1;
        public winOlvidoPassword()
        {
            InitializeComponent();
        }
        void EnableButtons()
        {
            btnUpdate.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnCancerlar.IsEnabled = true;
            txtContraseña.IsEnabled = true;
            txtContraseña.Focus();
            txtCorreoElectroinico.IsEnabled = true;
            txtCorreoElectroinico.Focus();
        }


        void DisableButtons()
        {
            btnUpdate.IsEnabled = true;

            btnSave.IsEnabled = false;
            btnCancerlar.IsEnabled = false;
            txtCorreoElectroinico.IsEnabled = false;
            txtContraseña.IsEnabled = false;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgvDatos_Loaded(object sender, RoutedEventArgs e)
        {
            //esto no era
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            EnableButtons();
            this.option = 2;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Modificar
            try
            {
                user.Password = txtContraseña.Text;
                user.UserEmail = txtCorreoElectroinico.Text;
                user.UserID = (short)lblId.Content; // cambiar si cambia la de admin
                implUser = new UserImpl();
                int res = implUser.AdminChangePass(user.UserID, txtContraseña.Text , txtCorreoElectroinico.Text);
                if (res > 0)                      //user.UserID
                {
                    MessageBox.Show("Registro Modificado con exito!");
                    LoadDataGrid();
                    DisableButtons();
                    enviarcorreo();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void enviarcorreo()
        { //PONER PARA QUE PASE LA CONTRASEÑA Y EL NOMBRE DE USUARIO
            string mensaje;
            string mensaje2;
            mensaje = "CONTRASEÑA DE ACCESO";
            mensaje2 = "Su Nueva contraseña es: " + txtContraseña.Text;

            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            mmsg.To.Add(txtCorreoElectroinico.Text);
            mmsg.Subject = mensaje;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            mmsg.Body = mensaje2;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new System.Net.Mail.MailAddress("Valcot2021@hotmail.com");


            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            cliente.Credentials = new System.Net.NetworkCredential("Valcot2021@hotmail.com", "valcot2001");
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.office365.com";

            try
            {
                cliente.Send(mmsg);
            }
            catch (Exception)
            {

                MessageBox.Show("Error al enviar");
            }
        }

        private void btnCancerlar_Click(object sender, RoutedEventArgs e)
        {
            DisableButtons();
        }

        private void lblrandompassword_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int longitud = 6;
            txtContraseña.Text = GenerarPassword(longitud);
        }
        public static string GenerarPassword(int longitud)
        {
            string contraseña = string.Empty;
            string[] letras = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
            Random EleccionAleatoria = new Random();

            for (int i = 0; i < longitud; i++)
            {
                int LetraAleatoria = EleccionAleatoria.Next(0, 100);
                int NumeroAleatorio = EleccionAleatoria.Next(0, 9);

                if (LetraAleatoria < letras.Length)
                {
                    contraseña += letras[LetraAleatoria];
                }
                else
                {
                    contraseña += NumeroAleatorio.ToString();
                }
            }
            return contraseña;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }
        void LoadDataGrid()
        {
            try
            {
                implUser = new UserImpl();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = implUser.Selec().DefaultView;
                dgvDatos.Columns[0].Visibility = Visibility.Collapsed;
                lblId.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvDatos.Items.Count > 0 && dgvDatos.SelectedItem != null)
            {
                try
                {
                    DataRowView dataRow = (DataRowView)dgvDatos.SelectedItem;
                    byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                    implUser = new UserImpl();
                    user = implUser.GetAdmin(id);
                    lblUsuario.Content = user.UserName;
                    txtCorreoElectroinico.Text = user.UserEmail;
                    lblId.Content = user.UserID;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
