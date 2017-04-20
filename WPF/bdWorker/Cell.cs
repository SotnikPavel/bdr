using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdWorker
{
    public class Cell
    {
        public Guid Id { get; set; }
        public int CellNumber { get; set; }
        public Guid StorageId { get; set; }
        public Storage Storage { get; set; }
    }
}
