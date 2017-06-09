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
    /// Логика взаимодействия для Storage.xaml
    /// </summary>
    public partial class Storage : Window
    {
        Guid UserId;
        public Storage(Guid userId)
        {
            InitializeComponent();
            UserId = userId;
            Reload();
        }

        private void Reload()
        {
            DataWorker.Storages dw = new DataWorker.Storages();
            dw.Load(UserId);
            ObservableCollection<DataWorker.Storages> ec = dw.StoragesData;
            DataContext = ec;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                StorageChanges storageShange = new StorageChanges((DataWorker.Storages)(list.SelectedItem), UserId);
                storageShange.ShowDialog();
                Reload();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            StorageAdd storageAdd = new StorageAdd(UserId);
            storageAdd.ShowDialog();
            Reload();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                DBWorker.Storages.Delete(((DataWorker.Storages)(list.SelectedItem)).Id);
                Reload();
            }
        }
    }
}
