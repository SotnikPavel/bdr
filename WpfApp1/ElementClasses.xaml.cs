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
    /// Логика взаимодействия для ElementClasses.xaml
    /// </summary>
    public partial class ElementClasses : Window
    {
        Guid UserId;
        public ElementClasses(int lang, Guid userId)
        {
            InitializeComponent();
            UserId = userId;
            if (lang == 1)
            {
                Change.Header = "үзгәртергә";
                Add.Header = "өстәргә";
                Delete.Header = "бетерә";
                TypeEl.Header = "Типы элементларын ";

            }
            Reload();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ElementClassesAdd eca = new ElementClassesAdd();
            eca.ShowDialog();
            Reload();
        }
        private void Reload()
        {
            DataWorker.ElementClasses dw = new DataWorker.ElementClasses();
            dw.Load(UserId);
            ObservableCollection<DataWorker.ElementClasses> ec = dw.ElementClassesData;
            DataContext = ec;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Guid? BaseId = null;
            if (list.SelectedItem != null)
            {
                BaseId = ((DataWorker.ElementClasses)(list.SelectedItem)).Id;
            }
            TypeElement typeElement = new TypeElement(BaseId);
            typeElement.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(list.SelectedItem != null)
            {
                DBWorker.ElementClasses.Delete(((DataWorker.ElementClasses)(list.SelectedItem)).Id);
                Reload();
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                ElementClassesChange elementClassesChange = new ElementClassesChange((DataWorker.ElementClasses)(list.SelectedItem));
                elementClassesChange.ShowDialog();
                Reload();
            }
        }
    }
}
