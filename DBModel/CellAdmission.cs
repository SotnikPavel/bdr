using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
     public class CellAdmission
    {
        public Guid Id { get; set; }
        public Guid ConsignmentId { get; set; }
        public int Quantity { get; set; }
        public string ReceiptDate { get; set; }
        public Consignment Consignment { get; set; }
    }
}
