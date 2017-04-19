using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace bdWorker
{
    public class UserContext:DbContext
    {
        public UserContext() : base("Data Source=bdrinstanse.c29uy4nro3g3.us-west-2.rds.amazonaws.com;Initial Catalog=bdr1;User ID=bdruser;Password=123ewqasdcxz")
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Producer> Producers { get; set; }
    }
}
