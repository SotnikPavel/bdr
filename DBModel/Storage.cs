using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class Storage
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public Guid StorageId { get; set; }
        public string RfidId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Storage> Storages { get; set; }
        public List<Availability> Availabilitys { get; set; }
    }
}
