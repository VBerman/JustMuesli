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

            var draggedMuesli = (e.Data.GetData(typeof(SendData)) as SendData).Muesli;
            if (draggedMuesli.TypeId == 1)
            {
                UsedMueslis.Remove(UsedMueslis[12]);
                UsedMueslis.Insert(12, new UsedMuesli() { Muesli = draggedMuesli });

            }
            else
            {
                var usedMuesli = (sender as StackPanel).DataContext as UsedMuesli;
                if (usedMuesli.Muesli != null)
                {
                    var rangeToTop = UsedMueslis.ToList().GetRange(0, UsedMueslis.IndexOf(usedMuesli) + 1);
                    rangeToTop.RemoveAt(0);
                    rangeToTop.Add(usedMuesli);

                    var usedMueslis = UsedMueslis.ToList();
                    usedMueslis.RemoveRange(0, UsedMueslis.IndexOf(usedMuesli) + 1);
                    usedMueslis.InsertRange(0, rangeToTop);

                    UsedMueslis = new ObservableCollection<UsedMuesli>(usedMueslis.ToList());

                }
                UsedMueslis.Remove(usedMuesli);
                UsedMueslis.Insert(UsedMueslis.IndexOf(usedMuesli), new UsedMuesli() { Muesli = draggedMuesli });

            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var itemDrag = sender as Border;
            Muesli muesli = itemDrag.DataContext as Muesli;
            var sendData = new SendData() { Muesli = muesli };
            DragDrop.DoDragDrop(itemDrag, sendData, DragDropEffects.Move);
        }

        private class SendData
        {
            public Muesli Muesli { get; set; }
        }

    }
}
