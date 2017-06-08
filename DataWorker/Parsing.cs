using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;
using System.Collections.ObjectModel;

namespace DataWorker
{
    public class Parsing
    {
        public ObservableCollection<string> ParsingData { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }

        public void Load()
        {
            ParsingData = GetClassesByParentId();
        }

        public Parsing()
        {

        }
        
        private ObservableCollection<string> GetClassesByParentId()
        {
            ObservableCollection<string> rc = new ObservableCollection<string>();
            var componentClasses = DBWorker.Parsing.Load();
            return componentClasses;
        }
    }

}
