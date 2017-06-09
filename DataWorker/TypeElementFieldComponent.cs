using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWorker
{
    public class TypeElementFieldComponent
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
        public TypeElementFieldComponent()
        {

        }
        public TypeElementFieldComponent(Guid id, string name, string value)
        {
            Id = id;
            Name = name;
            Value = value;
        }
        public TypeElementFieldComponent(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
