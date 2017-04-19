using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdWorker
{
    public class Storage
    {
        public Guid Id { get; set; }
        public Guid StorageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Storage> Storages { get; set; }
        public List<Cell> Cells { get; set; }
    }
}
