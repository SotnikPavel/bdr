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
        public Producer()
        {
            InitializeComponent();
            Reload();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ProducerAdd producerAdd = new ProducerAdd();
            producerAdd.ShowDialog();
            Reload();
        }

        private void Reload()
        {
            DataContext = DBWorker.Producers.GetList();
        }
    }
}
