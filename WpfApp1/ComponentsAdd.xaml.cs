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
    /// Логика взаимодействия для ComponentsAdd.xaml
    /// </summary>
    public partial class ComponentsAdd : Window
    {
        private DataWorker.ElementClasses baseElement = new DataWorker.ElementClasses();
        public ComponentsAdd()
        {
            InitializeComponent();
            Load();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Guid producerId = new Guid();
            Guid bodyId = new Guid();
            if (Producer.SelectedItem != null)
            {
                producerId = ((DBModel.Producer)(Producer.SelectedItem)).Id;
            }
            if (ElementBody.SelectedItem != null)
            {
                bodyId = ((DBModel.ShellType)(ElementBody.SelectedItem)).Id;
            }
            DBWorker.Components.Add(Name.Text, producerId, bodyId, baseElement.Id);
            Close();
        }

        private void Load()
        {
            DataWorker.ComponentsAdd componentsAdd = new DataWorker.ComponentsAdd();
            componentsAdd.Load();
            DataContext = componentsAdd;
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
