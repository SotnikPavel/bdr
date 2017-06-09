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
using System.Collections.ObjectModel;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для TypeElement.xaml
    /// </summary>
    public partial class TypeElement : Window
    {
        Guid? ParentId;
        public TypeElement(Guid? ParentId)
        {
            InitializeComponent();
            this.ParentId = ParentId;
            //if(lang ==1)
            // {
            //     Change.Header = "үзгәртергә";
            //  Add.Header = "өстәргә";
            //  Delete.Header = "бетерә";
            // }
            Reload();
        }
        private void Reload()
        {
            DataWorker.TypeElementClasses dw = new DataWorker.TypeElementClasses();
            dw.Load(ParentId);
            ObservableCollection<DataWorker.TypeElementClasses> ec = dw.TypeElementClassesData;
            DataContext = ec;
        }

        private void Add_click(object sender, RoutedEventArgs e)
        {
            TypeElementAdd typeElementAdd = new TypeElementAdd(ParentId);
            typeElementAdd.ShowDialog();
            Reload();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if(listView.SelectedItem != null)
            {
                TypeElementChange typeElementChange = new TypeElementChange((DataWorker.TypeElementClasses)(listView.SelectedItem));
                typeElementChange.ShowDialog();
                Reload();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                DBWorker.TypeElement.Delete(((DataWorker.TypeElementClasses)(listView.SelectedItem)).Id);
                Reload();
            }
        }

        private void Field_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                TypeElementField typeElementField = new TypeElementField(((DataWorker.TypeElementClasses)(listView.SelectedItem)).Id);
                typeElementField.ShowDialog();
            }
        }
    }
}
