using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BeginingDate { get; set; }
        public string EndDate { get; set; }
        public Guid StatusId { get; set; }
        public Status Status { get; set; }
        public List<Project_Device> Projects_Devices { get; set; }
    }
}
