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
    /// Логика взаимодействия для ElementBodiesChange.xaml
    /// </summary>
    public partial class ElementBodiesChange : Window
    {
        DBModel.ShellType ShellType;
        public ElementBodiesChange(DBModel.ShellType shellType)
        {
            InitializeComponent();
            ShellType = shellType;
            DataContext = shellType;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShellType.Name = Name.Text;
            ShellType.Description = Description.Text;
            ShellType.PinsQuantity = int.Parse(PinCount.Text);
            DBWorker.ShellTypes.Change(ShellType);
            Close();
        }
    }
}
