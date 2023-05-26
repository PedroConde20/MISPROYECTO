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

namespace KapDB.Cliente
{
    /// <summary>
    /// Lógica de interacción para winFindClientByName.xaml
    /// </summary>
    public partial class winFindClientByName : Window
    {
        Product wine;
        ProductImpl implWine;
        public winFindClientByName()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgvDatos_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void dgvDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtFind.Text.Trim() !="" && txtFind.Text.Length >1)
            {
                try
                {
                    implWine = new ProductImpl();
                    dgvDatos.ItemsSource = null;
                    dgvDatos.ItemsSource = implWine.SelectLikeByName(txtFind.Text).DefaultView;
                    dgvDatos.Columns[0].Visibility = Visibility.Collapsed;

                }
                catch (Exception)
                {
                    MessageBox.Show("No es posible completar la accion \nComuniquese con el administrador");
                }
            }
            else
            {
                dgvDatos.ItemsSource = null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dgvDatos.Items.Count > 0 && dgvDatos.SelectedItem != null)
            {
                try
                {
                    DataRowView dataRow = (DataRowView)dgvDatos.SelectedItem;
                    DataClass.ClassID =dataRow.Row.ItemArray[0].ToString();
                    DataClass.ClassData1 = dataRow.Row.ItemArray[1].ToString();
                    DataClass.ClassData2 = dataRow.Row.ItemArray[2].ToString();
                    DataClass.ClassData3 = txtQuantity.Text;
                    //DataClass.ClassData4 = dataRow.Row.ItemArray[4].ToString();
                    this.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            if (dgvDatos.Items.Count > 0 && dgvDatos.SelectedItem != null && txtQuantity.Text.Trim() != "")
            {
                try
                {
                    DataRowView dataRow = (DataRowView)dgvDatos.SelectedItem;
                    DataClass.ClassID = dataRow.Row.ItemArray[0].ToString();
                    DataClass.ClassData1 = dataRow.Row.ItemArray[1].ToString();
                    DataClass.ClassData2 = dataRow.Row.ItemArray[2].ToString();
                    DataClass.ClassData3 = txtQuantity.Text;
                    //DataClass.ClassData4 = dataRow.Row.ItemArray[4].ToString();
                    this.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No es posible realizar la accion");
                }
            }
        }
    }
}
