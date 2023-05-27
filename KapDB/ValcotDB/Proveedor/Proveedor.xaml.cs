using DAO.Implementation;
using DAO.Model;
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

namespace ValcotDB.Proveedor
{
    /// <summary>
    /// Lógica de interacción para Proveedor.xaml
    /// </summary>
    public partial class Proveedor : Window
    {
        SupplierImpl implSupplier;
        Supplier supplier;
        sbyte option = -1;
        public Proveedor()
        {
            InitializeComponent();
        }
        void LoadDataGrid()
        {
            try
            {
                implSupplier = new SupplierImpl();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = implSupplier.Selec().DefaultView;
                dgvDatos.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {

                MessageBox.Show("No es posible completar la transaccion\n Comuniquese con el Adm. de sistemas");
            }
        }

        void EnableButtons()
        {
            btnInsert.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            txtNombreProveedor.IsEnabled = true;
            txtNombreProveedor.Focus();
            txtApellidoProveedor.IsEnabled = true;
            txtApellidoProveedor.Focus();
            txtCodigoProveedor.IsEnabled = true;
            txtCodigoProveedor.Focus();
            txtDireccion.IsEnabled = true;
            txtDireccion.Focus();
            txtTelefono.IsEnabled = true;
            txtTelefono.Focus();
            txtemail.IsEnabled = true;
            txtemail.Focus();
        }


        void DisableButtons()
        {
            btnInsert.IsEnabled = true;
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;

            btnSave.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            txtNombreProveedor.IsEnabled = false;
            txtApellidoProveedor.IsEnabled = false;
            txtCodigoProveedor.IsEnabled = false;
            txtDireccion.IsEnabled = false;
            txtTelefono.IsEnabled = false;
            txtemail.IsEnabled = false;
        }

        private void btnCancerlar_Click(object sender, RoutedEventArgs e)
        {
            DisableButtons();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgvDatos.SelectedItem != null && dgvDatos.Items.Count > 0)
            {
                if (MessageBox.Show("Esta realmente segur@ \nde eliminar el registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        implSupplier = new SupplierImpl();
                        int res = implSupplier.Delete(supplier);
                        if (res > 0)
                        {
                            MessageBox.Show(res + "Registro Eliminado ");
                            LoadDataGrid();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("No es posible hacer eso");
                    }
                }
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            EnableButtons();
            this.option = 1;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            switch (this.option)
            {
                case 1: //insertar
                    try
                    {
                        supplier = new Supplier(txtNombreProveedor.Text, txtApellidoProveedor.Text, txtCodigoProveedor.Text, txtDireccion.Text, txtTelefono.Text, txtemail.Text, Session.SessionID);
                        implSupplier = new SupplierImpl();
                        int res = implSupplier.Insert(supplier);
                        if (res > 0)
                        {
                            MessageBox.Show("Registro Insertado con exito!");

                            LoadDataGrid();
                            DisableButtons();

                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("No es posible completar la transaccion\nComuniquese con el adm de sistemas");
                    }
                    break;

                case 2: //Moodificar
                    try
                    {
                        DataRowView dataRow = (DataRowView)dgvDatos.SelectedItem;
                        byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                        supplier.SupplierName = txtNombreProveedor.Text;
                        supplier.SupplierLastName = txtApellidoProveedor.Text;
                        supplier.SupplierCI = txtCodigoProveedor.Text;
                        supplier.SupplierDirection = txtDireccion.Text;
                        supplier.SupplierCellphone = txtTelefono.Text;
                        supplier.SupplierEmail = txtemail.Text;
                        supplier.UserID = (Byte)Session.SessionID;
                        implSupplier = new SupplierImpl();
                        int res = implSupplier.Update(supplier);

                        if (res > 0)
                        {
                            MessageBox.Show("Registro Modificado con exito!");
                            LoadDataGrid();
                            DisableButtons();
                        }

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("No es posible completar la transaccion\nComuniquese con el adm de sistemas");
                    }

                    break;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            EnableButtons();
            this.option = 2;
        }

        private void dgvDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvDatos.Items.Count > 0 && dgvDatos.SelectedItem != null)
            {
                try
                {

                    DataRowView dataRow = (DataRowView)dgvDatos.SelectedItem;
                    byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                    implSupplier = new SupplierImpl();
                    supplier = implSupplier.Get(id);
                    txtCodigoProveedor.Text = supplier.SupplierCI;
                    txtDireccion.Text = supplier.SupplierDirection;
                    txtemail.Text = supplier.SupplierEmail;
                    txtNombreProveedor.Text = supplier.SupplierName;
                    txtApellidoProveedor.Text = supplier.SupplierLastName;
                    txtTelefono.Text = supplier.SupplierCellphone;
                }
                catch (Exception)
                {

                    MessageBox.Show("No es posible completar la transaccion\nComuniquese con el adm de sistemas");
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

            DisableButtons();
        }
    }
}
