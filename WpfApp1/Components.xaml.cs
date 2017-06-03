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
using System.Collections.ObjectModel;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Components.xaml
    /// </summary>
    public partial class Components : Window
    {
        public Components()
        {
            InitializeComponent();
            Reload();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ComponentsAdd componentsAdd = new ComponentsAdd();
            componentsAdd.ShowDialog();
            Reload();
        }
        private void Reload()
        {
            DataWorker.Components dw = new DataWorker.Components();
            ObservableCollection<DataWorker.Component> ec = dw.GetList();
            DataContext = ec;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var t = listView.SelectedItem;
            if(t != null)
            {
                Guid idElementForDelete = ((DataWorker.Component)t).Id;
                DBWorker.Components.Delete(idElementForDelete);
            }
            Reload();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
