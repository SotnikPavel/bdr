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
        public static void Init()
        {
            using (UserContext DB = new UserContext())
            {
                var nel = DB.ComponentClasses.Where(n => n.Id == Guid.Empty).FirstOrDefault();
                if(nel == null)
                {
                    ComponentClass cc = new ComponentClass();
                    cc.Id = Guid.Empty;
                    cc.ComponentClassId = Guid.Empty;
                    cc.Description = "Base";
                    cc.Name = "Base";
                    DB.ComponentClasses.Add(cc);
                }
                DB.SaveChanges();

                var nelc = DB.Countries.Where(n => n.Id == Guid.Empty).FirstOrDefault();
                if (nelc == null)
                {
                    Country cc = new Country();
                    cc.Id = Guid.Empty;
                    cc.Name = "Base";
                    DB.Countries.Add(cc);
                }
                DB.SaveChanges();

                var nelp = DB.Producers.Where(n => n.Id == Guid.Empty).FirstOrDefault();
                if (nelp == null)
                {
                    Producer cc = new Producer();
                    cc.Id = Guid.Empty;
                    cc.CountryId = Guid.Empty;
                    cc.Description = "Base";
                    cc.Name = "Base";
                    DB.Producers.Add(cc);
                }

                var nelt = DB.TypeElements.Where(n => n.Id == Guid.Empty).FirstOrDefault();
                if (nelt == null)
                {
                    DBModel.TypeElement cc = new DBModel.TypeElement();
                    cc.Id = Guid.Empty;
                    cc.Description = "Base";
                    cc.Name = "Base";
                    DB.TypeElements.Add(cc);
                }
                var nels = DB.ShellTypes.Where(n => n.Id == Guid.Empty).FirstOrDefault();
                if (nels == null)
                {
                    ShellType cc = new ShellType();
                    cc.Id = Guid.Empty;
                    cc.Description = "Base";
                    cc.Name = "Base";
                    DB.ShellTypes.Add(cc);
                }

                DB.SaveChanges();
            }
        }
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
