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
    /// Логика взаимодействия для TypeElementField.xaml
    /// </summary>
    public partial class TypeElementField : Window
    {
        Guid TypeElementId;
        public TypeElementField(Guid typeElementId)
        {
            InitializeComponent();
            TypeElementId = typeElementId;
            Reload();
        }

        private void Reload()
        {
            DataContext = DBWorker.TypeElementFields.GetList(TypeElementId);
        }

        private void MenuItem_Add(object sender, RoutedEventArgs e)
        {
            TypeElemntFieldAdd typeElemntFieldAdd = new TypeElemntFieldAdd(TypeElementId);
            typeElemntFieldAdd.ShowDialog();
            Reload();
        }

        private void MenuItem_Delete(object sender, RoutedEventArgs e)
        {
            if(listView.SelectedItem != null)
            {
                DBWorker.TypeElementFields.Delete(((DBModel.TypeElementField)(listView.SelectedItem)).Id);
                Reload();
            }
        }
    }
}
