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
    /// Логика взаимодействия для TypeElementClassesBaseClassSelect.xaml
    /// </summary>
    public partial class TypeElementClassesBaseClassSelect : Window
    {
        public DataWorker.TypeElementClasses BaseElement { get; set; }
        public TypeElementClassesBaseClassSelect()
        {
            InitializeComponent();
            LoadContext();
        }
        private void LoadContext()
        {
            DataWorker.TypeElementClasses dw = new DataWorker.TypeElementClasses();
            dw.Load(null);
            ObservableCollection<DataWorker.TypeElementClasses> ec = dw.TypeElementClassesData;
            DataContext = ec;
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            BaseElement = (DataWorker.TypeElementClasses)(e.NewValue);
            Close();
        }
    }
}
