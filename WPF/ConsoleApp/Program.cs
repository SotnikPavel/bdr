using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bdWorker;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UserContext DB = new UserContext())
            {
                Country cn = new Country();
                cn.Id = Guid.NewGuid();
                cn.Name = "123";
                DB.Countries.Add(cn);

                DB.SaveChanges();
            }

        }
    }
}
