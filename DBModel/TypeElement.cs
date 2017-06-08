using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class TypeElement
    {
        public Guid Id { get; set; }
        public Guid ComponentClassId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Component> Components { get; set; }
    }
}
