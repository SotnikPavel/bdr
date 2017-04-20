using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Producer> Producers { get; set; }
    }
}
