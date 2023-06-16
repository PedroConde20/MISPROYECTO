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

namespace KapDB.Cliente
{
    /// <summary>
    /// Lógica de interacción para winAdmClients.xaml
    /// </summary>
    public partial class winAdmClients : Window
    {
        ClienteImpl implClient;
        Client client;
        sbyte option = -1;
        public winAdmClients()
        {
            InitializeComponent();
        }
        void LoadDataGrid()
        {
            try
            {
                implClient = new ClienteImpl();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = implClient.Selec().DefaultView;
                dgvDatos.Columns[0].Visibility = Visibility.Collapsed;
                dgvDatos.Columns[7].Visibility = Visibility.Collapsed;
                dgvDatos.Columns[8].Visibility = Visibility.Collapsed;
                dgvDatos.Columns[9].Visibility = Visibility.Collapsed;
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
            btnCancerlar.IsEnabled = true;
            txtNombreCliente.IsEnabled = true;
            txtNombreCliente.Focus();
            txtApellidoCliente.IsEnabled = true;
            txtApellidoCliente.Focus();
            txtCiCliente.IsEnabled = true;
            txtCiCliente.Focus();
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
            btnCancerlar.IsEnabled = false;
            txtNombreCliente.IsEnabled = false;
            txtApellidoCliente.IsEnabled = false;
            txtCiCliente.IsEnabled = false;
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
                        implClient = new ClienteImpl();
                        int res = implClient.Delete(client);
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
                        client = new Client(txtNombreCliente.Text, txtApellidoCliente.Text,txtCiCliente.Text,txtDireccion.Text,txtTelefono.Text,txtemail.Text,Session.SessionID);
                        implClient = new ClienteImpl();
                        int res = implClient.Insert(client);
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
                        client.ClientName = txtNombreCliente.Text;
                        client.ClientLastName = txtApellidoCliente.Text;
                        client.ClientCI = txtCiCliente.Text;
                        client.ClientDirection = txtDireccion.Text;
                        client.ClientTelephone = txtTelefono.Text;
                        client.ClientEmail = txtemail.Text;
                        client.ClientID = (Byte)Session.SessionID;
                        implClient = new ClienteImpl();
                        int res = implClient.Update(client);
                        if (res > 0)
                        {
                            MessageBox.Show("Registro Modificado con exito!");
                            LoadDataGrid();
                            DisableButtons();
                        }
                        else
                        {
                            MessageBox.Show("no hay datos para insertar");
                        }

                    }
                    catch (Exception )
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
            MessageBox.Show("actualizar");
        }

        private void dgvDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvDatos.Items.Count > 0 && dgvDatos.SelectedItem != null)
            {
                try
                {
    
                    DataRowView dataRow = (DataRowView)dgvDatos.SelectedItem;
                    byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                    implClient = new ClienteImpl();
                    client = implClient.Get(id);
                    txtCiCliente.Text = client.ClientCI;
                    txtDireccion.Text = client.ClientDirection;
                    txtemail.Text = client.ClientEmail;
                    txtNombreCliente.Text = client.ClientName;
                    txtApellidoCliente.Text = client.ClientLastName;
                    txtTelefono.Text = client.ClientTelephone;
                }
                catch (Exception )
                {

                    MessageBox.Show("No es posible completar la transaccion\nComuniquese con el adm de sistemas");
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }
    }
}
