using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;

namespace DBWorker
{
    public static class TypeElementFieldComponents
    {
        public static List<DBModel.TypeElementFieldComponents> GetListByClassId(Guid componentId)
        {
            using (UserContext DB = new UserContext())
            {
                return DB.TypeElementFieldComponentss.Where(n => n.ComponentId == componentId).ToList();
            }
        }

        public static void Change(Guid id, string value)
        {
            using (UserContext DB = new UserContext())
            {
                var typeElementFieldComponents = DB.TypeElementFieldComponentss.Where(n => n.Id == id).First();
                typeElementFieldComponents.Value = value;
                DB.SaveChanges();
            }
        }

        public static void AddToAllComponentsInType(Guid typeComponents, Guid typeElementFieldId)
        {
            using (UserContext DB = new UserContext())
            {
                var listComponents = Components.GetListInType(typeComponents);
                foreach(var component in listComponents)
                {
                    DBModel.TypeElementFieldComponents typeElementFieldComponents = new DBModel.TypeElementFieldComponents();
                    typeElementFieldComponents.Id = Guid.NewGuid();
                    typeElementFieldComponents.ComponentId = component.Id;
                    typeElementFieldComponents.TypeElementFieldId = typeElementFieldId;
                    DB.TypeElementFieldComponentss.Add(typeElementFieldComponents);
                    DB.SaveChanges();
                }
            }
        }

        public static DBModel.TypeElementFieldComponents GetGuidByComponentIdTypeElementFieldId(Guid componentId, Guid typeElementFieldId)
        {
            using (UserContext DB = new UserContext())
            {
                return DB.TypeElementFieldComponentss.Where(n => n.ComponentId == componentId && n.TypeElementFieldId == typeElementFieldId).First();
            }
        }

        public static void Add(Guid componentId, Guid typeElementFieldId)
        {
            using (UserContext DB = new UserContext())
            {
                DBModel.TypeElementFieldComponents typeElementFieldComponents = new DBModel.TypeElementFieldComponents();
                typeElementFieldComponents.Id = Guid.NewGuid();
                typeElementFieldComponents.ComponentId = componentId;
                typeElementFieldComponents.TypeElementFieldId = typeElementFieldId;
                DB.TypeElementFieldComponentss.Add(typeElementFieldComponents);
                DB.SaveChanges();
            }
        }

    }
}
