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
    /// Логика взаимодействия для TypeElementAdd.xaml
    /// </summary>
    public partial class TypeElementAdd : Window
    {
        private DataWorker.ElementClasses baseElement = new DataWorker.ElementClasses();
        Guid? ParentId;
        public TypeElementAdd(Guid? ParentId)
        {
            InitializeComponent();
            baseElement.Id = ParentId == null ? Guid.Empty : ParentId.Value;
            if(ParentId != null)
            {
                Button3.Content = DBWorker.ElementClasses.GetById(ParentId.Value).Name;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(baseElement.Id != null)
            {
                DBWorker.TypeElement.Add(Name.Text, Description.Text, baseElement.Id);
                Close();
            }
            else
            {
                Error er = new Error("baseElement not selected");
                er.ShowDialog();
            }
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
