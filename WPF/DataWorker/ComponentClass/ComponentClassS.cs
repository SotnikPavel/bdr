using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWorker.ComponentClass
{
    public class ComponentClassS
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ComponentClassS> ComponentClasses { get; set; }

        public ComponentClassS(Guid Id, string Name, string Description, List<ComponentClassS> ComponentClasses)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.ComponentClasses = ComponentClasses;
        }

        public ComponentClassS()
        {
            this.ComponentClasses = new List<ComponentClassS>();
        }
    }
}
