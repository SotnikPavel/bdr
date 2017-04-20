using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class Project_Device
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public Guid ProjectId { get; set; }
        public string Quantity { get; set; }
        public Device Device { get; set; }
        public Project Project { get; set; }
    }
}
