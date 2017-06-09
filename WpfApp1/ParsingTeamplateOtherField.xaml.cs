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
    /// Логика взаимодействия для ParsingTeamplateOtherField.xaml
    /// </summary>
    public partial class ParsingTeamplateOtherField : Window
    {
        Guid ParsingId;
        public ParsingTeamplateOtherField(string parsingId)
        {
            InitializeComponent();
            ParsingId = DBWorker.Parsing.GetByName(parsingId).Id;
            Reload();
        }

        public void Reload()
        {
            DataContext = DataWorker.TypeElementFieldComponents.GetListComponents(ParsingId);
        }

        private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                TypeElementFieldComponentsAdd TypeElementFieldComponentsAdd = new TypeElementFieldComponentsAdd();
                TypeElementFieldComponentsAdd.ShowDialog();
                DBWorker.ParsingOtherFields.Change(((DataWorker.TypeElementFieldComponent)listView.SelectedItem).Id, TypeElementFieldComponentsAdd.ValueR);
            }
            Reload();
        }
    }
}
