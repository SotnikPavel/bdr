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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для StorageChanges.xaml
    /// </summary>
    public partial class StorageChanges : Window
    {
        DataWorker.Storages SelectedItem;
        private DataWorker.Storages baseStorage = new DataWorker.Storages();
        Guid UserId;
        public StorageChanges(DataWorker.Storages SelectedItem, Guid userId)
        {
            InitializeComponent();
            UserId = userId;
            this.SelectedItem = SelectedItem;
            SelectedItem.BaseClassLoad();
            DataContext = SelectedItem;
        }

        private void Parent_Click(object sender, RoutedEventArgs e)
        {
            StoragesBaseClassSelect storagesBaseClassSelect = new StoragesBaseClassSelect(UserId, SelectedItem.Id);
            storagesBaseClassSelect.ShowDialog();

            if (storagesBaseClassSelect.BaseStorage != null)
            {
                baseStorage = storagesBaseClassSelect.BaseStorage;
                Parent.Content = baseStorage.Name;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DBWorker.Storages.Change(Name.Text, Description.Text, RfidId.Text, baseStorage.Id, SelectedItem.Id);
            Close();
        }
    }
}
