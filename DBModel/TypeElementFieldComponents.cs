using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class TypeElementFieldComponents
    {
        public Guid Id { get; set; }
        public Guid ComponentId { get; set; }
        public Guid TypeElementFieldId { get; set; }
        public string Value { get; set; }
    }
}
