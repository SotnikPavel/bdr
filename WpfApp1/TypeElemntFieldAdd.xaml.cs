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
    /// Логика взаимодействия для TypeElemntFieldAdd.xaml
    /// </summary>
    public partial class TypeElemntFieldAdd : Window
    {
        private Guid TypeElementId;
        public TypeElemntFieldAdd(Guid typeElementId)
        {
            InitializeComponent();
            TypeElementId = typeElementId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DBWorker.TypeElementFields.Add(TypeElementId, Name.Text);
            Close();
        }
    }
}
