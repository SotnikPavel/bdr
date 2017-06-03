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
    /// Логика взаимодействия для TypeElement.xaml
    /// </summary>
    public partial class TypeElement : Window
    {
        public TypeElement()
        {
            InitializeComponent();
        }

        private void Add_click(object sender, RoutedEventArgs e)
        {
            TypeElementAdd add = new TypeElementAdd();
            add.ShowDialog();
        }

       

        
    }
}
