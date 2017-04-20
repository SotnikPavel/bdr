using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdWorker
{
    public class Unit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public Guid UnitTypeId { get; set; }
        public decimal Multiplier { get; set; }
        public UnitType UnitTypes { get; set; }
        public List<Characteristic> Characteristics { get; set; }

    }
}
