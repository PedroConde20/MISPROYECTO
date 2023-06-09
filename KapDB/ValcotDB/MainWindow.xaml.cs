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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DAO.Implementation;
using DAO.Model;
using KapDB.CambioContraUs;
using ValcotDB.Proveedor;

namespace KapDB
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void lvwMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridMain.Children.Clear();
        }
      

        private void btnCollapseMenu_Click(object sender, RoutedEventArgs e)
        {
            btnCollapseMenu.Visibility = Visibility.Collapsed;  
            btnOpenMenu.Visibility = Visibility.Visible;
        }

        private void btnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btnCollapseMenu.Visibility = Visibility.Visible;  
            btnOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void lvwMenu2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MENU A
            UserControl usc = null;

            gridMain.Children.Clear();


            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "itemB":
                    break;

                case "itemA":
                    usc = new Stock.uscStock();
                    break;
            }
            if (usc != null)
            {
                gridMain.Children.Add(usc);
            }
        }

        private void lvwMenuC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "www.google.com.ar");
        }

        private void btnRedirigir_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "www.google.com.ar");
        }

        private void btnAcercaDe_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            usc = new AcercaDe.uscAcercaDe();
            gridMain.Children.Add(usc);
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //ERROR NO TOCAR PORFAVOR
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            txtUserInfo.Text = "Usuario : " + Session.SessionUsername + " - Rol: " + Session.SessionRole;
            //Privilegios del Menu
            switch (Session.SessionRole)
            {
                case "Administrador":
                    break;
                case "Empleado":
                   // itemUsuarios.Visibility = Visibility.Collapsed;
                    //itemTransacciones.Visibility = Visibility.Collapsed;
                    btnOlvidoPassword.Visibility = Visibility.Collapsed;

                    break;
                case "Contador":
                   // itemUsuarios.Visibility = Visibility.Collapsed;
                   // itemClient.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            CambioContraUs.winCambiodeContra win = new winCambiodeContra();
            
            win.ShowDialog();
        }

        
        private void btnOlvidoPassword_Click(object sender, RoutedEventArgs e)
        {
            OlvidoPassword.winOlvidoPassword win = new OlvidoPassword.winOlvidoPassword();
            win.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //E
            Cliente.winFindClientByName win = new Cliente.winFindClientByName();
            win.ShowDialog();
        }
       
        private void btnReportes_Click(object sender, RoutedEventArgs e)
        {
            Reportes.winReports win = new Reportes.winReports();
            win.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;

            gridMain.Children.Clear();

            usc = new Usuarios.Usuarios();
            gridMain.Children.Add(usc);
        }

        private void btnVentas_Click(object sender, RoutedEventArgs e)
        {
            Transacciones.winTransaction win = new Transacciones.winTransaction();

            win.ShowDialog();
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;

            gridMain.Children.Clear();

            usc = new Stock.uscStock();
            gridMain.Children.Add(usc);
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            Cliente.winAdmClients win = new Cliente.winAdmClients();

            win.ShowDialog();
        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            gridMain.Children.Clear();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnProveedores_Click(object sender, RoutedEventArgs e)
        {

            uscProveedores win = new uscProveedores();
            win.ShowDialog();
        }
    }
}
