using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;

namespace DBWorker
{
    public class DBWorker
    {
        static void Main(string[] args)
        {
            DBWorker dw = new DBWorker();
            dw.LevelComponentClassList();
        }
        public void LevelComponentClassList()
        {
            using (UserContext DB = new UserContext())
            {
                Country cn = new Country();
                cn.Id = Guid.NewGuid();
                cn.Name = "123";
                //var tu = DB.Countries.ToList();
                DB.Countries.Add(cn);

                DB.SaveChanges();
            }
            
        }
    }
}
