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
            DataContext = DBWorker.User.GetUserById(UserId);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DBWorker.User.AddData(UserId, Name.Text, LastName.Text, Number.Text);
            Close();
        }
    }
}
