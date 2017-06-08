using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DataWorker
{
    public class Reports
    {
        public static void SaveReport(Guid userId)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();
            if (!string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
            {
                Components components = new Components();
                var rcomponents = components.GetList(userId);
                string text ="Название;Класс;Тип;Производитель\n";
                foreach (var rcomponent in rcomponents)
                {
                    text += rcomponent.Name + ";" + rcomponent.Class + ";" + rcomponent.BodyType + ";" + rcomponent.Producer + "\n";
                }
                File.WriteAllText(folderBrowser.SelectedPath + "/report.csv", text, Encoding.UTF8);

            }

        }
    }
}
