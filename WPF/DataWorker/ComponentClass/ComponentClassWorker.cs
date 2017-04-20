using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DataWorker.ComponentClass
{
    public class ComponentClassWorker
    {
        public ObservableCollection<ComponentClassS> ComponentClassS { get; set; }

        public ComponentClassWorker()
        {
            ComponentClassS = new ObservableCollection<ComponentClassS>();
        }
    }
}
