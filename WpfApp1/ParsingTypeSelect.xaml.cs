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
    /// Логика взаимодействия для ParsingTypeSelect.xaml
    /// </summary>
    public partial class ParsingTypeSelect : Window
    {
        Guid UserId;
        public ParsingTypeSelect(int lang, Guid userId)
        {
            InitializeComponent();
            UserId = userId;
            if (lang == 1)
            {
                FromSite.Content = "Сайтыннан";
                FromCSV.Content = "Белән csv";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Parsing parsing = new Parsing(UserId);
            parsing.ShowDialog();
        }
    }
}
