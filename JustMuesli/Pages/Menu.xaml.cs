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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void ButtonEditCustomerDetailsOpen(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditCustomerDetails());

        }
        //ToDo:add just muesli
        private void ButtonMixOpen(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Mix());
        }
        private void ButtonMyMuesliMixesOpen(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MyMuesliMixes());

        }
        private void ButtonOrderOpen(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Order());

        }
        private void ButtonExit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0); 
        }

        
    }
}
