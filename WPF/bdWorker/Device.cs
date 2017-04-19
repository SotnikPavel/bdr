using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdWorker
{
    public class Device
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public List<Project_Device> Projects_Devices { get; set; }
        public List<Component> Components { get; set; }
    }
}
