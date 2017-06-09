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
    /// Логика взаимодействия для ComponentStorages.xaml
    /// </summary>
    public partial class ComponentStorages : Window
    {
        Guid ComponentId;
        Guid UserId;

        public ComponentStorages(Guid userId, Guid componentId)
        {
            InitializeComponent();
            ComponentId = componentId;
            UserId = userId;
            Reload();
        }

        private void Reload()
        {
            DataContext = DataWorker.ComponentStorages.GetList(ComponentId);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ComponentStoragesAdd componentStoragesAdd = new ComponentStoragesAdd(UserId, ComponentId);
            componentStoragesAdd.ShowDialog();
            Reload();
        }

        private void MenuItem_Change(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                ComponentStorageShange componentStorageShange = new ComponentStorageShange(UserId, ComponentId, (DataWorker.ComponentStorage)listView.SelectedItem);
                componentStorageShange.ShowDialog();
            }
            Reload();
        }

        private void MenuItem_Delete(object sender, RoutedEventArgs e)
        {
            if(listView.SelectedItem != null)
            {
                DBWorker.Availability.Delete(((DataWorker.ComponentStorage)listView.SelectedItem).Name, ComponentId);
            }
        }
    }
}
