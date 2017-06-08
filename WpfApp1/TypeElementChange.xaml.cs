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
    /// Логика взаимодействия для TypeElementChange.xaml
    /// </summary>
    public partial class TypeElementChange : Window
    {
        DataWorker.TypeElementClasses SelectedItem;
        private DataWorker.ElementClasses baseElement = new DataWorker.ElementClasses();
        public TypeElementChange(DataWorker.TypeElementClasses SelectedItem)
        {
            InitializeComponent();
            this.SelectedItem = SelectedItem;
            SelectedItem.BaseClassLoad();
            baseElement.Id = SelectedItem.BaseClassId;
            DataContext = SelectedItem;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DBWorker.TypeElement.Change(textBlock.Text, textBlock22.Text, baseElement.Id, SelectedItem.Id);
            Close();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            ElementClassesBaseClassSelect elementClassesBaseClassSelect = new ElementClassesBaseClassSelect { };
            elementClassesBaseClassSelect.ShowDialog();

            if (elementClassesBaseClassSelect.BaseElement != null)
            {
                baseElement = elementClassesBaseClassSelect.BaseElement;
                Button3.Content = baseElement.Name;
            }
        }
    }
}
