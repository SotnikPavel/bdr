using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdWorker
{
    public class PhoneNumber
    {
        public Guid Id { get; set; }
        public Guid ProviderId { get; set; }
        public string Number { get; set; }
        public Provider Provider { get; set; }
    }
}
