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
    /// Логика взаимодействия для ElementClasses.xaml
    /// </summary>
    public partial class ElementClasses : Window
    {
        public ElementClasses()
        {
            InitializeComponent();
            Reload();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ElementClassesAdd eca = new ElementClassesAdd();
            eca.ShowDialog();
            Reload();
        }
        private void Reload()
        {
            DataWorker.ElementClasses dw = new DataWorker.ElementClasses();
            dw.Load();
            ObservableCollection<DataWorker.ElementClasses> ec = dw.ElementClassesData;
            DataContext = ec;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if(ElementsClasses.SelectedItem != null)
            {

                DBWorker.ElementClasses.Delete(((DataWorker.ElementClasses)ElementsClasses.SelectedItem).Id);
            }
            Reload();
        }

        private void TypeElementcall(object sender, RoutedEventArgs e)
            
        {
            TypeElement typeelem = new TypeElement();
            typeelem.ShowDialog();
            
        }
        
    }
}
