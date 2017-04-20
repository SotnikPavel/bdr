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
using DataWorker.ComponentClass;
using DBWorker;

namespace BDR
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DBWorker.DBWorker dbw = new DBWorker.DBWorker();
            ComponentClassWorker ccw = new ComponentClassWorker();

            foreach(var tcomponentClass in dbw.LevelComponentClassList(Guid.Empty).FirstOrDefault().ComponentClasses)
            {
                ccw.ComponentClassS.Add(tcomponentClass);
            }

            ComponentClass сomponentClass = new ComponentClass();
            сomponentClass.DataContext = ccw;
            сomponentClass.ShowDialog();
        }
    }
}
