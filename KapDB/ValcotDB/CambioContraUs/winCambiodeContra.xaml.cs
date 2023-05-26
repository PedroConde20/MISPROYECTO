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

namespace KapDB.CambioContraUs
{
    /// <summary>
    /// Lógica de interacción para winCambiodeContra.xaml
    /// </summary>
    public partial class winCambiodeContra : Window
    {
        UserImpl UserImpl;
        User user;
        sbyte option = -1;
        public winCambiodeContra()
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
            txtRepetirContraseña.IsEnabled = true;
            txtRepetirContraseña.Focus();

        }


        void DisableButtons()
        {
            btnUpdate.IsEnabled = true;

            btnSave.IsEnabled = false;
            btnCancerlar.IsEnabled = false;
            txtContraseña.IsEnabled = false;
            txtRepetirContraseña.IsEnabled = false;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            EnableButtons();
            this.option = 1;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtContraseña.Password.Trim() != "" && txtRepetirContraseña.Password.Trim() != "")
                {
                    if (txtContraseña.Password.Trim().Length >= 6 && txtRepetirContraseña.Password.Trim().Length >= 6)
                    {
                        if (txtContraseña.Password.Trim() == txtContraseña.Password.Trim())
                        {
                            try
                            {
                                UserImpl = new UserImpl();
                                int resp = UserImpl.ChangePassAlready(Session.SessionID, txtContraseña.Password);
                                if (resp > 0)
                                {
                                    MessageBox.Show("Registro Modificado con exito!");
                                    DisableButtons();
                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);
                            }
                        }
                        else MessageBox.Show("Las Contraseñas No coinciden");
                    }
                    else MessageBox.Show("La contraseña debe tener minimo 6 digios");
                }
                else MessageBox.Show("Debe cambiar obligatoriamente la contraseña");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancerlar_Click(object sender, RoutedEventArgs e)
        {
            DisableButtons();
        }
    }
}
