using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdWorker
{
    public class UnitType
    {
        public Guid Id { get; set; }
        public int Name { get; set; }
        public List<Unit> Units { get; set; }
    }
}
