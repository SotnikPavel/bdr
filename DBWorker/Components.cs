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
        public static List<Component> GetListInType(Guid typeElementId)
        {
            List<Component> producer;
            using (UserContext DB = new UserContext())
            {
                producer = DB.Components.Where(n => n.ComponentClassId == typeElementId).ToList();
            }
            return producer;
        }
        public List<Component> GetList(Guid userId)
        {
            List<Component> producer;
            using (UserContext DB = new UserContext())
            {
                producer = DB.Components.Where(n => n.UserId == userId).ToList();
            }
            return producer;
        }
        public static Guid Add(Guid userId, string name, Guid producerId, Guid shellTypeId, Guid typeElementId)
        {
            using (UserContext DB = new UserContext())
            {
                Component component = new Component();
                component.UserId = userId;
                component.Id = Guid.NewGuid();
                component.Name = name;
                component.ProducerId = producerId;
                component.ShellTypeId = shellTypeId;
                component.ComponentClassId = typeElementId;
                DB.Components.Add(component);
                DB.SaveChanges();
                TypeElementFields.AddExemplar(typeElementId, component.Id);
                return component.Id;
            }
        }
        public static void Change(Guid oldId, string name, Guid producerId, Guid shellTypeId, Guid componentClassId)
        {
            using (UserContext DB = new UserContext())
            {
                Component component = DB.Components.Where(n => n.Id == oldId).First();
                component.Name = name;
                component.ProducerId = producerId;
                component.ShellTypeId = shellTypeId;
                component.ComponentClassId = componentClassId;
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

        public static Component GetById(Guid id)
        {
            using (UserContext DB = new UserContext())
            {
                Component component = DB.Components.Where(n => n.Id == id).FirstOrDefault();
                return component;
            }
        }
    }
}
