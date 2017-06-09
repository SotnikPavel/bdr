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
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private Guid UserId;
        public Settings(int lang, Guid userId)
        {
            InitializeComponent();
            UserId = userId;
            if (lang == 1)
            {
                NameS.Content = "Исемен";
                Surname.Content = "Фамилиясе";
                Phone.Content = "Телефон";
                Save.Content = "Саклап";
            }
            var user = DBWorker.User.GetUserById(UserId);
            DataContext = user;
            RfidWorker.RfidRead rw = new RfidWorker.RfidRead();
            List<string> ports = rw.GetPorts();
            foreach(string port in ports)
            {
                Port.Items.Add(port);
            }
            Port.SelectedIndex = Port.Items.IndexOf(user.PortName);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string portName = "";
            if(Port.SelectedItem != null)
            {
                portName = Port.SelectedItem.ToString();
            }
            DBWorker.User.AddData(UserId, Name.Text, LastName.Text, Number.Text, portName);
            Close();
        }
    }
}
