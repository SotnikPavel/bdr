using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;
using System.Collections.ObjectModel;

namespace DBWorker
{
    public class ElementClasses
    {
        public static void Delete(Guid id)
        {
            using (UserContext context = new UserContext())
            {
                var componentClass = context.ComponentClasses.Where(o => o.Id == id).FirstOrDefault();
                CascadeDelete(id);
                context.ComponentClasses.Remove(componentClass);
                context.SaveChanges();
            }
        }
        public static void CascadeDelete(Guid parentId)
        {
            using (UserContext context = new UserContext())
            {
                var listComponentClass = context.ComponentClasses.Where(o => o.ComponentClassId == parentId).ToList();
                foreach(var componentClass in listComponentClass)
                {
                    CascadeDelete(componentClass.Id);
                    context.ComponentClasses.Remove(componentClass);
                }
                context.SaveChanges();
            }
        }

        public static ComponentClass GetById(Guid id)
        {
            ComponentClass componentClass;
            using (UserContext DB = new UserContext())
            {
                componentClass = DB.ComponentClasses.Where(n => n.Id == id).FirstOrDefault(); 

            }
            return componentClass;
        }

        public void Add(string name, string description, Guid parentId)
        {
            using (UserContext DB = new UserContext())
            {
                ComponentClass componentClass = new ComponentClass();
                componentClass.Id = Guid.NewGuid();
                componentClass.Name = name;
                componentClass.Description = description;
                componentClass.ComponentClassId = parentId;
                DB.ComponentClasses.Add(componentClass);
                DB.SaveChanges();
            }
        }

        public ObservableCollection<ComponentClass> GetByParentId(Guid parentId)
        {
            ObservableCollection<ComponentClass> componentClasses;
            using (UserContext DB = new UserContext())
            {
                componentClasses = new ObservableCollection<ComponentClass>(DB.ComponentClasses.Where(n => n.ComponentClassId == parentId).ToList());
            }
            return componentClasses;
        }
    }
}
