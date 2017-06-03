using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;

namespace DBWorker
{
    public class Components
    {
        public List<Component> GetList()
        {
            List<Component> producer;
            using (UserContext DB = new UserContext())
            {
                producer = DB.Components.ToList();
            }
            return producer;
        }
        public static void Add(string name, Guid producerId, Guid shellTypeId, Guid componentClassId)
        {
            using (UserContext DB = new UserContext())
            {
                Component component = new Component();
                component.Id = Guid.NewGuid();
                component.Name = name;
                component.ProducerId = producerId;
                component.ShellTypeId = shellTypeId;
                component.ComponentClassId = componentClassId;
                DB.Components.Add(component);
                DB.SaveChanges();
            }
        }
        public static void Delete(Guid id)
        {
            using (UserContext DB = new UserContext())
            {
                Component component = DB.Components.Where(n => n.Id == id).FirstOrDefault();
                if(component != null)
                {

                    DB.Components.Remove(component);
                    DB.SaveChanges();
                }
            }
        }
    }
}
