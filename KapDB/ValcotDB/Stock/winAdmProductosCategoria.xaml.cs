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


namespace KapDB.Stock
{
    /// <summary>
    /// Lógica de interacción para winAdmTiposdeVinos.xaml
    /// </summary>
    public partial class winAdmTiposdeVinos : Window
    {

        CategoryImpl implCategory;
        Category category;
        sbyte option = -1;
        public winAdmTiposdeVinos()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void LoadDataGrid()
        {
            try
            {
                implCategory = new CategoryImpl();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource= implCategory.Selec().DefaultView;
                dgvDatos.Columns[0].Visibility = Visibility.Collapsed;
                dgvDatos.Columns[3].Visibility = Visibility.Collapsed;
                dgvDatos.Columns[4].Visibility = Visibility.Collapsed;
                dgvDatos.Columns[5].Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void EnableButtons()
        {
            btnInsert.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnCancerlar.IsEnabled = true;
            txtCategoryWine.IsEnabled = true;
            txtCategoryWine.Focus();
            txtDescriptionWine.IsEnabled = true;
            txtDescriptionWine.Focus();
        }


        void DisableButtons()
        {
            btnInsert.IsEnabled = true;
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;

            btnSave.IsEnabled = false;
            btnCancerlar.IsEnabled = false;
            txtCategoryWine.Text = "";
            txtCategoryWine.IsEnabled = false;
            txtDescriptionWine.Text = "";
            txtDescriptionWine.IsEnabled = false;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
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
            if (dgvDatos.SelectedItem !=null && dgvDatos.Items.Count>0)
            {
                if (MessageBox.Show("Esta realmente segur@ \nde eliminar el registro?","Eliminar",MessageBoxButton.YesNo, MessageBoxImage.Information)==MessageBoxResult.Yes)
                {
                    try
                    {
                        implCategory = new CategoryImpl();
                        int res = implCategory.Delete(category);
                        if (res >0)
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

        private void btnCancerlar_Click(object sender, RoutedEventArgs e)
        {
            DisableButtons();
        }

        private void dgvDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvDatos.Items.Count>0 && dgvDatos.SelectedItem!=null)
            {
                try
                {
                    DataRowView dataRow = (DataRowView)dgvDatos.SelectedItem;
                    byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                    implCategory = new CategoryImpl();
                    category =  implCategory.Get(id);
                    txtCategoryWine.Text = category.CategoryName;
                    txtDescriptionWine.Text = category.CategoryDescription;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No es posible hacer eso");
                }
            }
        }

        private void dgvDatos_Loaded(object sender, RoutedEventArgs e)
        {
            //este no es no lo toques 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            switch (this.option)
            {
                case 1: //insertar
                    try
                    {
                        category = new Category(txtCategoryWine.Text, txtDescriptionWine.Text,Session.SessionID);
                        implCategory = new CategoryImpl();
                        int res = implCategory.Insert(category);
                        if (res>0)
                        {
                            MessageBox.Show("Registro Insertado con exito!");
                            LoadDataGrid();
                            DisableButtons();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("No es posible hacer eso");
                    }
                    break;

                case 2: //Moodificar
                    try
                    {
                        category.CategoryName = txtCategoryWine.Text;
                        category.CategoryDescription = txtDescriptionWine.Text;
                        category.UserID = Session.SessionID;
                        implCategory = new CategoryImpl();
                       int res = implCategory.Update(category);
                        if (res>0)
                        {
                            MessageBox.Show("Registro Modificado con exito!");
                            LoadDataGrid();
                            DisableButtons();
                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                    break;
            }
        }
    }
}
