using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class ParsingParameter
    {
        public Guid Id { get; set; }
        public string Field { get; set; }
        public string ValueTemplate { get; set; }
    }
}
