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
using DAO.Implementation;
using DAO.Model;

namespace ValcotDB.Proveedor
{
    /// <summary>
    /// Lógica de interacción para verProveedores.xaml
    /// </summary>
    public partial class verProveedores : Window

    {
        SupplierImpl supplierImpl;
        int id;
        public verProveedores()
        {
            InitializeComponent();
            LoadCategory();
        }


        public void LoadCategory()
        {
            try
            {
                supplierImpl = new SupplierImpl();
                cbxProveedoresList.ItemsSource = null;
                //mostrar elementos
                cbxProveedoresList.DisplayMemberPath = "nombrecompleto";
                cbxProveedoresList.SelectedValuePath = "supplierID";

                cbxProveedoresList.ItemsSource = supplierImpl.SelectProveedores().DefaultView;
                cbxProveedoresList.SelectedIndex = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void cbxProveedoresList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id = Convert.ToByte(cbxProveedoresList.SelectedValue);
                supplierImpl = new SupplierImpl();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = supplierImpl.selectOneSupplier(id).DefaultView;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgvDatos_Loaded(object sender, RoutedEventArgs e)
        {
            dgvDatos.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void dgvDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
