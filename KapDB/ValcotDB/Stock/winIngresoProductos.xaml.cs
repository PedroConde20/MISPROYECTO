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
using Microsoft.Win32;
using System.IO;

namespace KapDB.Stock
{
    
    public partial class winIngresoVinos : Window
    {
        /// <summary>
        /// 1 Insert
        /// 2 Update
        /// </summary>
        byte option;
        sbyte optioncrud = -1;

        string ruta;
        
        SupplierImpl implSupplier;
        CategoryImpl implCategory;
        Category category;
        Product product;
        ProductImpl implProduct;
        public winIngresoVinos(byte option)
        {
            InitializeComponent();
            this.option = option;
            switch (this.option)
            {
                case 1:
                    txtTitle.Text = "Registrar Producto";
                    break;

                case 2:
                    txtTitle.Text = "Modificar Producto";
                    break;

            }
        }
        void EnableButtons()
        {
            btnInsertar.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            cbxCategoryProduct.IsEnabled = true;
            cbxCategoryProduct.Focus();
            cbxProveedorProduct.IsEnabled = true;
            cbxProveedorProduct.Focus();
            txtNombreProduct.IsEnabled = true;
            txtNombreProduct.Focus();
            txtPrecio.IsEnabled = true;
            txtPrecio.Focus();
            txtStock.IsEnabled = true;
            txtStock.Focus();
            txtDescripcion.IsEnabled = true;
            txtDescripcion.Focus();
            btnAgregarImagen.IsEnabled = true;

        }

        void DisableButtons()
        {
            btnInsertar.IsEnabled = true;
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;

            btnSave.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            cbxCategoryProduct.IsEnabled = false;

            cbxProveedorProduct.IsEnabled = false;
            txtNombreProduct.IsEnabled = false;
            txtPrecio.IsEnabled = false;
            txtStock.IsEnabled = false;
            txtDescripcion.IsEnabled = false;
            btnAgregarImagen.IsEnabled = false;
        }
        public void LoadCategory()
        {
            try
            {
                implCategory = new CategoryImpl();
                cbxCategoryProduct.ItemsSource = null;
                //mostrar elementos
                cbxCategoryProduct.DisplayMemberPath = "categoryName";

                cbxCategoryProduct.SelectedValuePath = "categoryID";
                cbxCategoryProduct.ItemsSource = implCategory.SelectForanea().DefaultView;
                cbxCategoryProduct.SelectedIndex = 0;

                implSupplier = new SupplierImpl();
                cbxProveedorProduct.ItemsSource = null;
                //mostrar elementos
                cbxProveedorProduct.DisplayMemberPath = "supplierName";

                cbxProveedorProduct.SelectedValuePath = "supplierID";
                cbxProveedorProduct.ItemsSource = implSupplier.SelectProveedor().DefaultView;
                cbxProveedorProduct.SelectedIndex = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        void LoadDataGrid()
        {
            try
            {
                implProduct = new ProductImpl();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = implProduct.Selec().DefaultView;
                dgvDatos.Columns[0].Visibility = Visibility.Collapsed;
                dgvDatos.Columns[3].Visibility = Visibility.Collapsed;
                dgvDatos.Columns[6].Visibility = Visibility.Collapsed;
                dgvDatos.Columns[7].Visibility = Visibility.Collapsed;
                dgvDatos.Columns[8].Visibility = Visibility.Collapsed;
                dgvDatos.Columns[9].Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {

                MessageBox.Show("No es posible completar la transaccion\n Comuniquese con el Adm. de sistemas");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string nombreProducto = Convert.ToString(txtNombreProduct.Text);
            double precio = Convert.ToDouble(txtPrecio.Text);
            int stock = Convert.ToInt32(txtStock.Text);
            string description = Convert.ToString(txtDescripcion.Text);

            switch (this.option)
            {
                case 1: //insertar
                    try
                    {
                        int id;
                        int res;
                        product = new Product(byte.Parse(cbxCategoryProduct.SelectedValue.ToString()),nombreProducto, precio, 1, stock,description,Session.SessionID,byte.Parse(cbxProveedorProduct.SelectedValue.ToString()));
                        id = implProduct.SaveId();
                        res = implProduct.Insert(product);
                        if (res > 0)
                        {
                            //File.Copy(ruta, Config.ProductImage + id + ".jpg");
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
                        int id;
                        id = Convert.ToInt32(dataRow.Row.ItemArray[0].ToString());
                        product.CategoryID = byte.Parse(cbxCategoryProduct.SelectedValue.ToString());
                        product.ProductName = txtNombreProduct.Text;
                        product.Price =Convert.ToDouble(txtPrecio.Text);
                        product.Stock = Convert.ToInt32(txtStock.Text);
                        product.DescriptionProduct = txtDescripcion.Text;
                        product.UserID = (Byte)Session.SessionID;
                        product.SupplierID = byte.Parse(cbxProveedorProduct.SelectedValue.ToString());

                        implProduct = new ProductImpl();
                        int res = implProduct.Update(product);
                        if (res > 0)
                        {
                            //modificar archivo
                            //eliminar archivo existente
                            //File.Delete(Config.ProductImage + id + ".jpg");
                            //copiar archivo nuevo
                            //File.Copy(ruta, Config.ProductImage + id + ".jpg");
                            MessageBox.Show("Registro Actualizado ".ToUpper());
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

        private void cbxCategoryProduct_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategory();
        }

        private void btnAgregarImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Archivos de Imagen|*.jpg";
            if (openFile.ShowDialog() == true)
            {
                ruta = openFile.FileName;
                imgFoto.Source = new BitmapImage(new Uri(ruta));
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DisableButtons();
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            EnableButtons();
            this.option = 1;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            EnableButtons();
            this.option = 2;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            if (dgvDatos.SelectedItem != null && dgvDatos.Items.Count > 0)
            {
                if (MessageBox.Show("Esta realmente segur@ \nde eliminar el registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        int id;
                        implProduct = new ProductImpl();
                        DataRowView dataRow = (DataRowView)dgvDatos.SelectedItem;
                        id = Convert.ToInt32(dataRow.Row.ItemArray[0].ToString());
                        int res = implProduct.Delete(product);
                        if (res > 0)
                        {
                            //File.Delete(Config.ProductImage + id +  ".jpg");
                            MessageBox.Show(res + "Registro Eliminado ");
                            LoadDataGrid();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
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

                    implProduct = new ProductImpl();
                    product = implProduct.Get(id);
                    txtNombreProduct.Text = product.ProductName;
                    txtPrecio.Text = product.Price.ToString();
                    //foto = product.Image.ToString();
                    txtPhoto.Text = product.Image.ToString();
                    txtStock.Text = product.Stock.ToString();
                    txtDescripcion.Text =product.DescriptionProduct;
                    cbxCategoryProduct.SelectedValue = product.CategoryID.ToString();
                    cbxProveedorProduct.SelectedValue = product.SupplierID.ToString();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No es posible completar la transaccion\nComuniquese con el adm de sistemas" + ex);
                }
            }
        }

        private void cbxProveedorProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //LoadCategory
        }

        public void LoadProveedor()
        {
            try
            {
                implSupplier = new SupplierImpl();
                cbxProveedorProduct.ItemsSource = null;
                //mostrar elementos
                cbxProveedorProduct.DisplayMemberPath = "supplierName";

                cbxProveedorProduct.SelectedValuePath = "supplierID";
                cbxProveedorProduct.ItemsSource = implSupplier.SelectProveedor().DefaultView;
                cbxProveedorProduct.SelectedIndex = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cbxProveedorProduct_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategory();
        }

        private void cbxProveedorProduct_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
