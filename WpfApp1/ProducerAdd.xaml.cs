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
    /// Логика взаимодействия для ProducerAdd.xaml
    /// </summary>
    public partial class ProducerAdd : Window
    {
        Guid UserId;
        public ProducerAdd(Guid userId)
        {
            InitializeComponent();
            UserId = userId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DBWorker.Producers dw = new DBWorker.Producers();
            dw.Add(UserId, Name.Text, Description.Text);
            Close();
        }
    }
}
