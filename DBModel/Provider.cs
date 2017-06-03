using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class Provider
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Site { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public List<Consignment> Consignments { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
    }
}
