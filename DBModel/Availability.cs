using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class Availability
    {
        public Guid Id { get; set; }
        public Guid ComponentId { get; set; }
        public Guid StorageId { get; set; }
        public int Count { get; set; }
    }
}
