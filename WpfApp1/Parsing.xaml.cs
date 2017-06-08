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
using ParsingSite = Parsing.ParsingSite;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Parsing.xaml
    /// </summary>
    public partial class Parsing : Window
    {
        Guid UserId;
        public Parsing(Guid userId)
        {
            InitializeComponent();
            UserId = userId;
            Reload();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ParsingTeamplateAdd parsingTeamplateAdd = new ParsingTeamplateAdd();
            parsingTeamplateAdd.ShowDialog();
            Reload();
        }

        private void Reload()
        {
            DataWorker.Parsing dw = new DataWorker.Parsing();
            dw.Load();
            DataContext = dw.ParsingData;
        }


        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if(parsingTeamplates.SelectedItem != null)
            {
                ParsingSite parsingSite = new ParsingSite(parsingTeamplates.SelectedItem.ToString());
                parsingSite.ParsingSiteByTeamplate(0, UserId);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (parsingTeamplates.SelectedItem != null)
            {
                DBWorker.Parsing.Delete(((string)(parsingTeamplates.SelectedItem)));
                Reload();
            }
        }
    }
}
