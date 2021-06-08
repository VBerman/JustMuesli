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
    /// Логика взаимодействия для Mix.xaml
    /// </summary>
    public partial class Mix : Page
    {




        public ObservableCollection<UsedMuesli> UsedMueslis
        {
            get { return (ObservableCollection<UsedMuesli>)GetValue(UsedMueslisProperty); }
            set { SetValue(UsedMueslisProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UsedMueslis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UsedMueslisProperty =
            DependencyProperty.Register("UsedMueslis", typeof(ObservableCollection<UsedMuesli>), typeof(Mix));


        public ObservableCollection<Models.Type> Types { get; set; } = new ObservableCollection<Models.Type>(DB.Instanse.Type.ToList());

        public CreatedMuesli CurrentMuesli { get; set; }


        public Mix(CreatedMuesli createdMuesli = null)
        {
            CurrentMuesli = createdMuesli ?? new CreatedMuesli();
            UsedMueslis = new ObservableCollection<UsedMuesli>(CurrentMuesli.UsedMuesli.Count != 0 ? CurrentMuesli.UsedMuesli.ToList() : Enumerable.Repeat(new UsedMuesli(), 13));

            InitializeComponent();
        }

        private void AddToMuesli(object sender, RoutedEventArgs e)
        {
            var addedMuesli = (sender as Hyperlink).DataContext as Muesli;

            if (addedMuesli.TypeId == 1)
            {
                UsedMueslis.Remove(UsedMueslis[12]);
                UsedMueslis.Insert(12, new UsedMuesli() { Muesli = addedMuesli });
            }
            else
            {
                UsedMueslis.Remove(UsedMueslis[0]);

                UsedMueslis.Insert(CountNull(), new UsedMuesli() { Muesli = addedMuesli });

            }


        }

        private int CountNull()
        {
            return UsedMueslis.Count(u => u.Muesli == null);
        }

        private void StackPanel_Drop(object sender, DragEventArgs e)
        {

            var a = e.Data.GetData(typeof(Muesli)) as Muesli;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var itemDrag = sender as Border;
            Muesli data = itemDrag.DataContext as Muesli;
            DragDrop.DoDragDrop(itemDrag, data, DragDropEffects.Move);
        }

        private void StackPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
        }
    }
}
