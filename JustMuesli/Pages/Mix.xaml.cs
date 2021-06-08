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
            UsedMueslis = new ObservableCollection<UsedMuesli>(CurrentMuesli.UsedMuesli.Count != 0 ? CurrentMuesli.UsedMuesli.ToList() : Enumerable.Range(0, 13).Select(x => new UsedMuesli()));

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
            var draggedUsedMuesli = new UsedMuesli() { Muesli = draggedMuesli };
            if (draggedMuesli.TypeId == 1)
            {
                UsedMueslis.Remove(UsedMueslis[12]);
                UsedMueslis.Insert(12, draggedUsedMuesli);

            }
            else
            {
                var usedMuesli = (sender as StackPanel).DataContext as UsedMuesli;
                var startMove = UsedMueslis.IndexOf(usedMuesli);

                if (CountSpaces() == 0)
                {

                }
                else if (UsedMueslis.ToList().GetRange(0, startMove).Count(a => a.Muesli == null) != 0 || UsedMueslis[0].Muesli == null)
                {
                    Put(startMove, draggedUsedMuesli, -1);
                }
                else
                {
                    Put(startMove, draggedUsedMuesli, 1);
                }
                CalculateBaseWeight();

            }
        }

        private void CalculateBaseWeight()
        {
            BaseWeight = -(UsedMueslis.Sum(a => a.Muesli == null ? 0 : a.Muesli.PortionSize) - 1200);
        }

        public int BaseWeight
        {
            get { return (int)GetValue(BaseWeightProperty); }
            set
            {
                SetValue(BaseWeightProperty, value);
                var a = (Mueslis.Items[12] as StackPanel);
            }
        }

        // Using a DependencyProperty as the backing store for BaseWeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BaseWeightProperty =
            DependencyProperty.Register("BaseWeight", typeof(int), typeof(Mix));




        private bool Put(int startIndex, UsedMuesli movedItem, int step)
        {
            if (UsedMueslis[startIndex].Muesli != null)
            {
                var newMovedItem = UsedMueslis[startIndex];
                UsedMueslis[startIndex] = movedItem;
                return Put(startIndex + step, newMovedItem, step);
            }
            else
            {
                UsedMueslis[startIndex] = movedItem;
                return true;
            }
        }



        private int CountSpaces()
        {
            return UsedMueslis.Count(a => a.Muesli == null);
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

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var numberMuesli = UsedMueslis.IndexOf((sender as StackPanel).DataContext as UsedMuesli);
            UsedMueslis.Remove((sender as StackPanel).DataContext as UsedMuesli);
            UsedMueslis.Insert(numberMuesli, new UsedMuesli());
        }
    }
}
