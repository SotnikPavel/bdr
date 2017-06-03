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
using DBWorkerC = DBWorker.ElementClasses;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ElementClassesAdd.xaml
    /// </summary>
    public partial class ElementClassesAdd : Window
    {
        private DBWorkerC DBWorker;
        private DataWorker.ElementClasses baseElement = new DataWorker.ElementClasses();
        public ElementClassesAdd()
        {
            InitializeComponent();
            DBWorker = new DBWorkerC();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DBWorker.Add(Name.Text, Description.Text, baseElement.Id);
            Close();
        }

        private void Parent_Click(object sender, RoutedEventArgs e)
        {
            ElementClassesBaseClassSelect elementClassesBaseClassSelect = new ElementClassesBaseClassSelect {  };
            elementClassesBaseClassSelect.ShowDialog();
            
            if(elementClassesBaseClassSelect.BaseElement != null)
            {
                baseElement = elementClassesBaseClassSelect.BaseElement;
                Parent.Content = baseElement.Name;
            }
        }
    }
}
