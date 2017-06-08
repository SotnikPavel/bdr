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
        Guid UserId;
        public ElementBodies(int lang, Guid userId)
        {
            InitializeComponent();
            UserId = userId;
            if (lang == 1)
            {
                Change.Header = "үзгәртергә";
                Add.Header = "өстәргә";
                Delete.Header = "бетерә";

            }
            Reload();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ElementBodiesAdd elementBodiesAdd = new ElementBodiesAdd(UserId);
            elementBodiesAdd.ShowDialog();
            Reload();
        }

        private void Reload()
        {
            DataContext =  DBWorker.ShellTypes.GetList();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if(listView.SelectedItem != null)
            {
                ElementBodiesChange elementBodiesChange = new ElementBodiesChange((DBModel.ShellType)listView.SelectedItem);
                elementBodiesChange.ShowDialog();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                DBWorker.ShellTypes.Delete((DBModel.ShellType)listView.SelectedItem);
                Reload();
            }
        }
    }
}
