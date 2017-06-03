using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class Consignment
    {
        public Guid Id { get; set; }
        public Guid ComponentId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid ProvidertId { get; set; }
        public string DeliveryDate { get; set; }
        public Component Component { get; set; }
        public Provider Provider { get; set; }
        public List<CellAdmission> CellAdmissions { get; set; }
        public List<CellConsumption> CellConsumptions { get; set; }
    }
}
