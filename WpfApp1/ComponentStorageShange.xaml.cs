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
    /// Логика взаимодействия для ComponentStorageShange.xaml
    /// </summary>
    public partial class ComponentStorageShange : Window
    {
        private DataWorker.Storages baseStorage;
        DataWorker.ComponentStorage SelectedItem;
        Guid UserId;
        Guid ComponentId;
        public ComponentStorageShange(Guid userId, Guid componentId, DataWorker.ComponentStorage selectedItem)
        {
            InitializeComponent();
            UserId = userId;
            this.SelectedItem = selectedItem;
            ComponentId = componentId;
            DataContext = SelectedItem;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int count;
            int.TryParse(Count.Text, out count);
            if (baseStorage != null)
            {
                DBWorker.Availability.Change(baseStorage.Name, count, ComponentId, SelectedItem.Name);
            }
            else
            {
                DBWorker.Availability.Change(SelectedItem.Name, count, ComponentId, SelectedItem.Name);
            }
            Close();
        }

        private void Parent_Click(object sender, RoutedEventArgs e)
        {
            StoragesBaseClassSelect storagesBaseClassSelect = new StoragesBaseClassSelect(UserId);
            storagesBaseClassSelect.ShowDialog();

            if (storagesBaseClassSelect.BaseStorage != null)
            {
                baseStorage = storagesBaseClassSelect.BaseStorage;
                Parent.Content = baseStorage.Name;
            }
        }
    }
}
