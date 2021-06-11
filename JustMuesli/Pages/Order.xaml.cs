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
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        private Models.Order currentOrder;
        public Models.Order CurrentOrder
        {
            get => currentOrder;
            set
            {
                currentOrder = value; CurrentOrder.OnPropertyChanged();
            }
        } 


        public Order(bool visibilityButton = false, Models.Order order = null)
        {
            
            
            if (order != null)
            {
                CurrentOrder = order;
            }
            else
            {
                CurrentOrder = new Models.Order();
                CurrentOrder.OrderMuesli = new List<OrderMuesli>(DB.Instanse.CreatedMuesli.ToList().Select(cm => new OrderMuesli() { CreatedMuesli = cm, Order = CurrentOrder }));

            }
            InitializeComponent();
            if (visibilityButton)
            {
                Back.Visibility = Visibility.Hidden;
                Submit.Visibility = Visibility.Hidden;
            }


        }

        private void BackToMenuButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }

        private void SubmitOrderButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.Instanse.Order.Add(CurrentOrder);
                CurrentOrder.Time = DateTime.Now;
                DB.Instanse.SaveChanges();
                MessageBox.Show("Success");
                NavigationService.Navigate(new Report(CurrentOrder));
            }
            catch (Exception ex)
            {

                MessageBox.Show("Not success");
            }
        }
    }
}
