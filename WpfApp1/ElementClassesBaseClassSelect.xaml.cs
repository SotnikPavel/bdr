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
    /// Логика взаимодействия для ElementClassesBaseClassSelect.xaml
    /// </summary>
    public partial class ElementClassesBaseClassSelect : Window
    {
        public DataWorker.ElementClasses BaseElement { get; set; }
        public ElementClassesBaseClassSelect()
        {
            InitializeComponent();
            LoadContext();
        }

        private void LoadContext()
        {
            DataWorker.ElementClasses dw = new DataWorker.ElementClasses();
            dw.Load();
            ObservableCollection<DataWorker.ElementClasses> ec = dw.ElementClassesData;
            DataContext = ec;
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            BaseElement = (DataWorker.ElementClasses)(e.NewValue);
            Close();
        }
    }
}
