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
    /// Логика взаимодействия для ComponentStoragesAdd.xaml
    /// </summary>
    public partial class ComponentStoragesAdd : Window
    {
        private DataWorker.Storages baseStorage = new DataWorker.Storages();
        Guid UserId;
        Guid ComponentId;
        public ComponentStoragesAdd(Guid userId, Guid componentId)
        {
            UserId = userId;
            ComponentId = componentId;
            InitializeComponent();
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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int count;
            int.TryParse(Count.Text, out count);
            DBWorker.Availability.Add(baseStorage.Id, ComponentId, count);
            Close();
        }
    }
}
