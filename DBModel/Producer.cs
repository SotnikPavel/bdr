using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class Producer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public List<Producer> Producers { get; set; }
    }
}
