using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdWorker
{
    public class CellConsumption
    {
        public Guid Id { get; set; }
        public Guid СonsignmentId { get; set; }
        public int Quantity { get; set; }
        public string ConsumptionDate { get; set; }
        public Guid ExpenditureReasonId { get; set; }
        public Consignment Consignment { get; set; }
        public ExpenditureReason ExpenditureReason { get; set; }
    }
}
