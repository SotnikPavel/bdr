using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class TypeElementField
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TypeElementId { get; set; }
        public List<TypeElementFieldComponents> TypeElementFieldComponentss { get; set; }
        public TypeElementField()
        {

        }
        public TypeElementField(string name, Guid typeElementId)
        {
            Id = Guid.NewGuid();
            Name = name;
            TypeElementId = typeElementId;
        }
    }
}
