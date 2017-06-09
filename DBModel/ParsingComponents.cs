using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class ParsingComponents
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string StartUrl { get; set; }
        public string NextUrl { get; set; }
        public string PathToElementPage { get; set; }
        public string PathToName { get; set; }
        public Guid ComponentsClassId { get; set; }
        public string PathToProducter { get; set; }
        public string PathToShellType { get; set; }
        public List<ParsingOtherField> ParsingOtherFields { get; set; }
    }
}
