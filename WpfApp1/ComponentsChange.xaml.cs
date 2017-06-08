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
    /// Логика взаимодействия для ComponentsChange.xaml
    /// </summary>
    public partial class ComponentsChange : Window
    {
        private DataWorker.TypeElementClasses baseElement = new DataWorker.TypeElementClasses();
        private DataWorker.Component Component;

        public ComponentsChange(DataWorker.Component Component)
        {
            InitializeComponent();
            Component.LoadClassId();
            this.Component = Component;
            baseElement.Id = Component.ClassId;
            Parent.Content = Component.Class;
            Load();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Component.ProducerId = new Guid();
            Component.ShellTypeId = new Guid();
            if (Producer.SelectedItem != null)
            {
                Component.ProducerId = ((DBModel.Producer)(Producer.SelectedItem)).Id;
            }
            if (ElementBody.SelectedItem != null)
            {
                Component.ShellTypeId = ((DBModel.ShellType)(ElementBody.SelectedItem)).Id;
            }
            DBWorker.Components.Change(Component.Id, Name.Text, Component.ProducerId, Component.ShellTypeId, baseElement.Id);
            Close();
        }

        private void Load()
        {
            DataWorker.ComponentsAdd componentsAdd = new DataWorker.ComponentsAdd();
            componentsAdd.Load();
            DataContext = componentsAdd;
            Name.Text = Component.Name;
        }

        private void Parent_Click(object sender, RoutedEventArgs e)
        {
            TypeElementClassesBaseClassSelect elementClassesBaseClassSelect = new TypeElementClassesBaseClassSelect { };
            elementClassesBaseClassSelect.ShowDialog();

            if (elementClassesBaseClassSelect.BaseElement != null)
            {
                baseElement = elementClassesBaseClassSelect.BaseElement;
                Parent.Content = baseElement.Name;
            }
        }
    }
}
