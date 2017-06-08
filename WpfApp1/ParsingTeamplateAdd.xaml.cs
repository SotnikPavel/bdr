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
using DBWorker;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ParsingTeamplateAdd.xaml
    /// </summary>
    public partial class ParsingTeamplateAdd : Window
    {
        private DataWorker.TypeElementClasses baseElement = new DataWorker.TypeElementClasses();

        public ParsingTeamplateAdd()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (baseElement != null)
            {
                DBWorker.Parsing.Add(StartUrl.Text, TeamplateName.Text, NextUrl.Text, PathToElementPage.Text, PathToName.Text, baseElement.Id, PathToProducter.Text, PathToShellType.Text);
                Close();
            }
        }

        private void Parent_Click(object sender, RoutedEventArgs e)
        {
            TypeElementClassesBaseClassSelect elementClassesBaseClassSelect = new TypeElementClassesBaseClassSelect { };
            elementClassesBaseClassSelect.ShowDialog();

            if (elementClassesBaseClassSelect.BaseElement != null)
            {
                baseElement = elementClassesBaseClassSelect.BaseElement;
                ComponentsClass.Content = baseElement.Name;
            }
        }
    }
}
