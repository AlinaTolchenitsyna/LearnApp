﻿using System;
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
    /// Логика взаимодействия для LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LogInWindow()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (DB.Client client in DB.LearnDBEntities.GetContext().Client.Where(c => c.FirstName == tbxLogin.Text && c.LastName == pbxPassword.Password))
                {
                    ProductsWindow productsWindow = new ProductsWindow();
                    productsWindow.Show();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("");
            }
        }
    }
}
