using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DBModel;

namespace DataWorker
{
    public class ComponentsAdd
    {
        public List<Producer> Producers { get; set; }
        public List<ShellType> ShellTypes { get; set; }

        public void Load()
        {
            Producers = DBWorker.Producers.GetList();
            ShellTypes = DBWorker.ShellTypes.GetList();
        }
    }
}
