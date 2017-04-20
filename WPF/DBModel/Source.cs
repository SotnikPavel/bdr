using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdWorker
{
    public class Source
    {
        public Guid Id { get; set; }
        public string URL { get; set; }
        public decimal Delay { get; set; }
        public List<ParsingPage> ParsingPages { get; set; }
    }
}
