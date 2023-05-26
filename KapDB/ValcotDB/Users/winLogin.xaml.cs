using System;
using System.Collections.Generic;
using System.Data;
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
using DAO.Implementation;
using DAO.Model;

namespace KapDB.Users
{
    /// <summary>
    /// Lógica de interacción para winLogin.xaml
    /// </summary>
    public partial class winLogin : Window
    {
        ConfigImpl configImpl;
        UserImpl implUser;

        public UserImpl UserImpl { get; private set; }

        public winLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUser.Text.Trim()!="" && txtPassword.Password.Trim() !="")
            {
                try
                {
                    implUser = new UserImpl();
                    DataTable dt = implUser.Login(txtUser.Text, txtPassword.Password);

                    if (dt.Rows.Count > 0)
                    {
                        configImpl = new ConfigImpl();
                        DataTable data;
                        data = configImpl.SelectConfig();
                        Config.ProductImage = data.Rows[0][0].ToString();
                        Config.UsuarioImage = data.Rows[0][1].ToString();
                        
                        Session.SessionID = short.Parse(dt.Rows[0][0].ToString());
                        Session.SessionUsername = dt.Rows[0][1].ToString();
                        Session.SessionRole = dt.Rows[0][2].ToString();
                        byte changePassword = byte.Parse(dt.Rows[0][3].ToString());
                        if (changePassword == 0)
                        {
                            dhChangePassword.Visibility = Visibility.Visible;
                            dhChangePassword.IsOpen = true;
                        }
                        else
                        {
                            OpenMenu();
                        }

                    }
                    else
                    {
                        txtInfo.Text = "Nombre de usuario y/o Contraseña Incorrecto";
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void OpenMenu()
        {
            MainWindow win = new MainWindow();
            win.ShowDialog();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (pwNewPassword.Password.Trim() != "" && pwConfirmPassword.Password.Trim() != "")
            {
                if (pwNewPassword.Password.Trim().Length >= 6 && pwConfirmPassword.Password.Trim().Length >= 6)
                {
                    if (pwNewPassword.Password.Trim() == pwConfirmPassword.Password.Trim())
                    {
                        try
                        {
                            UserImpl = new UserImpl();
                            int resp = UserImpl.ChangePassword(Session.SessionID, pwNewPassword.Password);
                            if (resp>0)
                            {
                                OpenMenu();
                                dhChangePassword.Visibility = Visibility.Collapsed;
                                dhChangePassword.IsOpen = false;
                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                    }
                    else txtMessagePassword.Text = "Las Contraseñas No coinciden";
                }
                else txtMessagePassword.Text = "La contraseña debe tener minimo 6 digios";
            }
            else txtMessagePassword.Text = "Debe cambiar obligatoriamente la contraseña";
        }
    }
}
