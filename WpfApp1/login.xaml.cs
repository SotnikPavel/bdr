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
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
            Lang.Items.Add("Русский");
            Lang.Items.Add("Татарский");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Guid? UserId = DBWorker.User.GetIdByLogin(Name.Text);
            if(UserId != null)
            {
                MainWindow mw = new MainWindow(UserId.Value, Lang.SelectedIndex);
                mw.Show();
                Close();
            }
            else
            {
                Error er = new Error("Пользователя не существует");
                er.ShowDialog();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bool res = DBWorker.User.Add(Name.Text);
            if(!res)
            {
                Error er = new Error("User Exists");
                er.ShowDialog();
            }
            DBWorker.DBWorker.Init();
        }
    }
}
