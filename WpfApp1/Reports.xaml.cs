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
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Reports.xaml
    /// </summary>
    public partial class Reports : Window
    {
        Guid UserId;
        public Reports(Guid userId)
        {
            InitializeComponent();
            UserId = userId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataWorker.Reports.SaveReport(UserId);
            Close();
        }
    }
}
