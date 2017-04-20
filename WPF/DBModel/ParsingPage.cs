using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class ParsingPage
    {
        public Guid Id { get; set; }
        public Guid SourceId { get; set; }
        public string URL { get; set; }
        public Guid ComponentId { get; set; }
        public string BlockPattern { get; set; }
        public Source Source { get; set; }
        public Component Component { get; set; }
    }
}
