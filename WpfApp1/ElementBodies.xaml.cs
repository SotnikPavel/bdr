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
    /// Логика взаимодействия для ElementBodies.xaml
    /// </summary>
    public partial class ElementBodies : Window
    {
        public ElementBodies()
        {
            InitializeComponent();
            Reload();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ElementBodiesAdd elementBodiesAdd = new ElementBodiesAdd();
            elementBodiesAdd.ShowDialog();
            Reload();
        }

        private void Reload()
        {
            DataContext =  DBWorker.ShellTypes.GetList();
        }
    }
}
