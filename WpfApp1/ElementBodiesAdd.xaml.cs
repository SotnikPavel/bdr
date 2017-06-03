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
    /// Логика взаимодействия для ElementBodiesAdd.xaml
    /// </summary>
    public partial class ElementBodiesAdd : Window
    {
        public ElementBodiesAdd()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DBWorker.ShellTypes DBWorker = new DBWorker.ShellTypes();
            DBWorker.Add(Name.Text, Description.Text, int.Parse(PinCount.Text));
            Close();
        }
    }
}
