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
    /// Логика взаимодействия для ElementClassesChange.xaml
    /// </summary>
    public partial class ElementClassesChange : Window
    {
        DataWorker.ElementClasses SelectedItem;
        private DataWorker.ElementClasses baseElement = new DataWorker.ElementClasses();
        public ElementClassesChange(DataWorker.ElementClasses SelectedItem)
        {
            InitializeComponent();
            this.SelectedItem = SelectedItem;
            SelectedItem.BaseClassLoad();
            DataContext = SelectedItem;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DBWorker.ElementClasses.Change(Name.Text, Description.Text, baseElement.Id, SelectedItem.Id);
            Close();
        }

        private void Parent_Click(object sender, RoutedEventArgs e)
        {
            ElementClassesBaseClassSelect elementClassesBaseClassSelect = new ElementClassesBaseClassSelect { };
            elementClassesBaseClassSelect.ShowDialog();

            if (elementClassesBaseClassSelect.BaseElement != null)
            {
                baseElement = elementClassesBaseClassSelect.BaseElement;
                Parent.Content = baseElement.Name;
            }
        }
    }
}
