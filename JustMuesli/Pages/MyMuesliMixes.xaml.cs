using JustMuesli.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для MyMuesliMixes.xaml
    /// </summary>
    public partial class MyMuesliMixes : Page
    {
        public ObservableCollection<CreatedMuesli> CreatedMueslis { get; set; } = new ObservableCollection<CreatedMuesli>(DB.Instanse.CreatedMuesli.ToList());
        public MyMuesliMixes()
        {
            InitializeComponent();
        }

        private void BackToMenuButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {
                NavigationService.Navigate(new Mix(DataGrid.SelectedItem as CreatedMuesli));

            }
            else
            {
                MessageBox.Show("Choose row");
            }
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {

            try
            {
                
                DB.Instanse.CreatedMuesli.Remove(DataGrid.SelectedItem as CreatedMuesli);
                DB.Instanse.SaveChanges();
                CreatedMueslis.Remove(DataGrid.SelectedItem as CreatedMuesli);
                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not success");

            }
        }
    }
}
