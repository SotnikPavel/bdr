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
    /// Логика взаимодействия для StoragesBaseClassSelect.xaml
    /// </summary>
    public partial class StoragesBaseClassSelect : Window
    {
        public DataWorker.Storages BaseStorage { get; set; }
        Guid UserId;
        Guid? IgnoreId;
        public StoragesBaseClassSelect(Guid userId, Guid? ignoreId = null)
        {
            InitializeComponent();
            UserId = userId;
            IgnoreId = ignoreId;
            LoadContext();
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            BaseStorage = (DataWorker.Storages)(e.NewValue);
            Close();
        }

        private void LoadContext()
        {
            DataWorker.Storages dw = new DataWorker.Storages();
            dw.Load(UserId, IgnoreId);
            ObservableCollection<DataWorker.Storages> ec = dw.StoragesData;
            DataContext = ec;
        }
        
    }
}
