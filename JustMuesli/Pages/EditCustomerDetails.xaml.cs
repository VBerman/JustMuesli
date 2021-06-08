﻿using JustMuesli.Models;
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

namespace JustMuesli.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditCustomerDetails.xaml
    /// </summary>
    public partial class EditCustomerDetails : Page
    {

        public User User { get; set; } = User.Load();

        public EditCustomerDetails()
        {
            InitializeComponent();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            var result = User.Save();
            if (result != "")
            {
                MessageBox.Show("Error:" + "\n" + result);
            }
            else
            {
                MessageBox.Show("Success");
            }
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
