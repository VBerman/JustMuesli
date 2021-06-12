using JustMuesli.Helpers;
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
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Page
    {
        public Report(Models.Order order)
        {

            InitializeComponent();
            RefreshLanguage.Refresh(this);
            Order.Content = new Pages.Order(visibilityButton: true, order: order);
            ContactInfo.Content = new EditCustomerDetails(true);

            
            

        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            NavigationService.GoBack();
        }
    }
}
