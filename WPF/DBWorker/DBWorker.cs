using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataWorker.ComponentClass;
using DBModel;

namespace DBWorker
{
    public class DBWorker
    {
        public List<ComponentClassS> LevelComponentClassList(Guid parentId)
        {
            List<ComponentClassS> levelComponentClassList = new List<ComponentClassS>();
            using (UserContext DB = new UserContext())
            {
                Country cn = new Country();
                cn.Id = Guid.NewGuid();
                cn.Name = "123";
                DB.Countries.Add(cn);

                DB.SaveChanges();
                var t = DB.ComponentClasses.FirstOrDefault();
                var componentClasses = DB.ComponentClasses.Where(n => n.ComponentClassId == parentId).ToList();
                foreach(var componetnClass in componentClasses)
                {
                    levelComponentClassList.Add(new ComponentClassS(componetnClass.Id, componetnClass.Name, componetnClass.Description, null));
                }
            }

            foreach(var componetnClass in levelComponentClassList)
            {
                componetnClass.ComponentClasses = LevelComponentClassList(componetnClass.Id);
            }

            return levelComponentClassList;
        }
    }
}
