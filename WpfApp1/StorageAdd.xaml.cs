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
    /// Логика взаимодействия для StorageAdd.xaml
    /// </summary>
    public partial class StorageAdd : Window
    {
        private DataWorker.Storages baseStorage = new DataWorker.Storages();
        Guid UserId;
        public StorageAdd(Guid userId)
        {
            UserId = userId;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DBWorker.Storages.Add(UserId, Name.Text, Description.Text, baseStorage.Id, RfidId.Text);
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
