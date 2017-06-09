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
using DBModel;
using System.Collections.Specialized;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Availability.xaml
    /// </summary>
    public partial class Availability : Window
    {
        Guid UserId;
        public Availability(Guid userId)
        {
            InitializeComponent();
            UserId = userId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StoragesBaseClassSelect storagesBaseClassSelect = new StoragesBaseClassSelect(UserId);
            storagesBaseClassSelect.ShowDialog();

            if (storagesBaseClassSelect.BaseStorage != null)
            {
                var baseStorage = storagesBaseClassSelect.BaseStorage;
                DataContext = DataWorker.Components.GetListInStorage(baseStorage.Id);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Read read = new Read(UserId);
            read.ShowDialog();
            string baseStorageRfidId = read.StorageId;
            if (baseStorageRfidId != "")
            {
                baseStorageRfidId = baseStorageRfidId.Substring(0, baseStorageRfidId.Length - 1);
                var baseStorage = DBWorker.Storages.GetByRfidId(baseStorageRfidId);
                if(baseStorage != null)
                {
                    DataContext = DataWorker.Components.GetListInStorage(baseStorage.Id);
                }
                else
                {
                    Error error = new Error("Storage with selected RfidId not found");
                    error.ShowDialog();
                }
            }
        }
    }
}
