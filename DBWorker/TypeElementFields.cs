using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;

namespace DBWorker
{
    public static class TypeElementFields
    {
        public static void Add(Guid typeElementId, string typeElementFieldName)
        {
            using (UserContext DB = new UserContext())
            {
                var typeElementField = new TypeElementField(typeElementFieldName, typeElementId);
                DB.TypeElementFields.Add(typeElementField);
                DB.SaveChanges();
                TypeElementFieldComponents.AddToAllComponentsInType(typeElementId, typeElementField.Id);
            }
        }

        public static void AddExemplar(Guid typeElementId, Guid componentId)
        {
            using (UserContext DB = new UserContext())
            {
                var typeElementFields = DB.TypeElementFields.Where(n => n.TypeElementId == typeElementId).ToList();
                foreach(var typeElementField in typeElementFields)
                {
                    TypeElementFieldComponents.Add(componentId, typeElementField.Id);
                }
            }
        }

        public static string GetNameById(Guid typeElementId)
        {
            using (UserContext DB = new UserContext())
            {
                return (DB.TypeElementFields.Where(n => n.Id == typeElementId).First()).Name;
            }
        }

        public static void Delete(Guid typeElementFieldId)
        {
            using (UserContext DB = new UserContext())
            {
                TypeElementField typeElementField = DB.TypeElementFields.Where(n => n.Id == typeElementFieldId).FirstOrDefault();
                DB.TypeElementFields.Remove(typeElementField);
                DB.SaveChanges();
            }
        }

        public static List<TypeElementField> GetList(Guid typeElementId)
        {
            List<TypeElementField> typeElementField;
            using (UserContext DB = new UserContext())
            {
                typeElementField = DB.TypeElementFields.Where(n => n.TypeElementId == typeElementId).ToList();
            }
            return typeElementField;
        }

    }
}
