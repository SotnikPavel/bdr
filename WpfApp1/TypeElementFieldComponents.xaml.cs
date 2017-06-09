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
    /// Логика взаимодействия для TypeElementFieldComponents.xaml
    /// </summary>
    public partial class TypeElementFieldComponents : Window
    {
        Guid ComponentId;
        public TypeElementFieldComponents(Guid componentId)
        {
            InitializeComponent();
            ComponentId = componentId;
            Reload();
        }

        public void Reload()
        {
            DataContext = DataWorker.TypeElementFieldComponents.GetList(ComponentId);
        }

        private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(listView.SelectedItem != null)
            {
                TypeElementFieldComponentsAdd TypeElementFieldComponentsAdd = new TypeElementFieldComponentsAdd();
                TypeElementFieldComponentsAdd.ShowDialog();
                DBWorker.TypeElementFieldComponents.Change(((DataWorker.TypeElementFieldComponent)listView.SelectedItem).Id, TypeElementFieldComponentsAdd.ValueR);
            }
            Reload();
        }
    }
}
