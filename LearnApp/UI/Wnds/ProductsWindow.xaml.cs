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

namespace LearnApp.UI.Wnds
{
    /// <summary>
    /// Логика взаимодействия для ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        public ProductsWindow()
        {
            InitializeComponent();
            lbxProducts.ItemsSource = DB.LearnDBEntities.GetContext().Service.ToList();
            if (lbxProducts.ItemsSource == null)
            {
                lblNoResults.Visibility = Visibility.Visible;
            }
        }

        public void UpdateServices()
        {
            var services = DB.LearnDBEntities.GetContext().Service.ToList();

            if (chbDiscount.IsChecked == true)
            {
                services = services.Where(s => s.Discount != null).ToList();
            }

            if (tbxName.Text != "")
            {
                services = services.Where(s => s.Title.ToLower().Contains(tbxName.Text.ToLower())).ToList();
            }

            if (cbSort.SelectedItem != null)
            {
                var selectedItem = ((ComboBoxItem)cbSort.SelectedItem).Content.ToString();

                switch (selectedItem)
                {
                    case "от а до я":
                        {
                            services = services.OrderBy(s => s.Title).ToList();
                            break;
                        }
                    case "от я до а":
                        {
                            services = services.OrderByDescending(s => s.Title).ToList();
                            break;
                        }
                }
            }

            
            lbxProducts.ItemsSource = services;
            if (services.Count() == 0)
            {
                lblNoResults.Visibility = Visibility.Visible;
            }
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateServices();
        }

        private void tbxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateServices();
        }

        private void chbDiscount_Click(object sender, RoutedEventArgs e)
        {
            UpdateServices();
        }
    }
}
