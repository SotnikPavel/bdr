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
    /// Логика взаимодействия для Read.xaml
    /// </summary>
    public partial class Read : Window
    {
        public string StorageId { get; set; }
        Guid UserId;
        public Read(Guid userId)
        {
            InitializeComponent();
            UserId = userId;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StorageId = "";
            System.Threading.Thread.Sleep(500);
            RfidWorker.RfidRead rfidRead = new RfidWorker.RfidRead();
            string resultString;
            bool result = rfidRead.ReadUid(DBWorker.User.GetUserPortNameById(UserId), out resultString);
            if (result == false)
            {
                Error error = new Error(resultString);
                error.ShowDialog();
                Close();
            }
            else
            {
                StorageId = resultString;
                Close();
            }
        }
    }
}
