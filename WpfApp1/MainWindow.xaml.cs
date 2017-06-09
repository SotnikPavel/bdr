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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Guid userId;
        int lang;
        public MainWindow(Guid userId, int lang)
        {
            InitializeComponent();
            this.userId = userId;
            this.lang = lang;
            if(lang == 1)
            {
                Classes.Header = "Бүлек";
                Import.Header = "Импорт";
                Report.Header = "Хисап";
                Propertys.Header = "Җайга салу";
                Components.Header = "Детальләрен";
                Shells.Header = "Корпусын";
                Producters.Header = "Җитештерүчеләр";
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ElementClasses elementClasses = new ElementClasses(lang, userId);
            elementClasses.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ElementBodies elementBodies = new ElementBodies(lang, userId);
            elementBodies.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Producer producer = new Producer(lang, userId);
            producer.ShowDialog();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Components components = new Components(lang, userId);
            components.ShowDialog();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Reports Reports = new Reports(userId);
            Reports.ShowDialog();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            Parsing parsing = new Parsing(userId);
            parsing.ShowDialog();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            Settings set = new Settings(lang, userId);
            set.ShowDialog();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            Storage storage = new Storage(userId);
            storage.ShowDialog();
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            Availability availability = new Availability(userId);
            availability.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
