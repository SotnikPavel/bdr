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
    /// Логика взаимодействия для Producer.xaml
    /// </summary>
    public partial class Producer : Window
    {
        Guid UserId;
        public Producer(int lang, Guid userId)
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
            ProducerAdd producerAdd = new ProducerAdd(UserId);
            producerAdd.ShowDialog();
            Reload();
        }

        private void Reload()
        {
            DataContext = DBWorker.Producers.GetList();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                ProducterChange producterChange = new ProducterChange(((DBModel.Producer)(listView.SelectedItem)));
                producterChange.ShowDialog();
                Reload();
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                DBWorker.Producers.Delete(((DBModel.Producer)(listView.SelectedItem)));
                Reload();
            }
        }
    }
}
