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
    /// Логика взаимодействия для Components.xaml
    /// </summary>
    public partial class Components : Window
    {
        Guid UserId;
        public Components(int lang, Guid userId)
        {
            InitializeComponent();
            UserId = userId;
            if (lang == 1)
            {
                Add.Header = "Өстәргә";
                Change.Header = "Үзгәртергә";
                Delete.Header = "Бетерә";
            }
            Reload();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ComponentsAdd componentsAdd = new ComponentsAdd(UserId);
            componentsAdd.ShowDialog();
            Reload();
        }
        private void Reload()
        {
            DataWorker.Components dw = new DataWorker.Components();
            ObservableCollection<DataWorker.Component> ec = dw.GetList(UserId);
            DataContext = ec;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var t = listView.SelectedItem;
            if(t != null)
            {
                Guid idElementForDelete = ((DataWorker.Component)t).Id;
                DBWorker.Components.Delete(idElementForDelete);
            }
            Reload();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            var t = listView.SelectedItem;
            if (t != null)
            {
                ComponentsChange componentsChange = new ComponentsChange((DataWorker.Component)listView.SelectedItem);
                componentsChange.ShowDialog();
                Reload();
            }
            Reload();
        }
        

        private void listView_SelectionChanged(object sender, MouseButtonEventArgs e)
        {
            ComponentStorages componentStorages = new ComponentStorages(UserId, ((DataWorker.Component)listView.SelectedItem).Id);
            componentStorages.ShowDialog();
        }

        private void MenuItem_Field(object sender, RoutedEventArgs e)
        {
            if(listView.SelectedItem != null)
            {
                TypeElementFieldComponents typeElementFieldComponents = new TypeElementFieldComponents((((DataWorker.Component)listView.SelectedItem).Id));
                typeElementFieldComponents.ShowDialog();
            }
        }
    }
}
