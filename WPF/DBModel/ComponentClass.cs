using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdWorker
{
    public class ComponentClass
    {
        public Guid Id { get; set; }
        public Guid ComponentClassId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ComponentClass> ComponentClasses { get; set; }
        public List<Component> Components { get; set; }

    }
}
