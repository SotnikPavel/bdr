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
    /// Логика взаимодействия для ProducterChange.xaml
    /// </summary>
    public partial class ProducterChange : Window
    {
        private DBModel.Producer producer;
        public ProducterChange(DBModel.Producer producer)
        {
            InitializeComponent();
            this.producer = producer;
            DataContext = producer;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            producer.Name = Name.Text;
            producer.Description = Description.Text;
            DBWorker.Producers.Change(producer);
            Close();
        }
    }
}
