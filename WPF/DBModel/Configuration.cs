using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdWorker
{
    public class Configuration
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool EditPermission { get; set; }
        public User User { get; set; }
    }
}
