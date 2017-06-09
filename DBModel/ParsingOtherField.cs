using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class ParsingOtherField
    {
        public Guid Id { get; set; }
        public Guid TypeElementFieldId { get; set; }
        public Guid ParsingComponentsId { get; set; }
        public string Value { get; set; }
        public ParsingOtherField()
        {

        }
        public ParsingOtherField(Guid id, Guid typeElementFieldId, Guid parsingComponentsId, string value = "")
        {
            Id = id;
            TypeElementFieldId = typeElementFieldId;
            ParsingComponentsId = parsingComponentsId;
            Value = value;
        }
    }
}
