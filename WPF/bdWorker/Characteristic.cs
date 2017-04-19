using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdWorker
{
    public class Characteristic
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public Guid UnitId { get; set; }
        public Unit Unit { get; set; }
        public List<Component> Component { get; set; }
    }
}
