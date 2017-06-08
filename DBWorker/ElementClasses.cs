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
        public static ComponentClass GetById(Guid id)
        {
            ComponentClass componentClass;
            using (UserContext DB = new UserContext())
            {
                componentClass = DB.ComponentClasses.Where(n => n.Id == id).FirstOrDefault();
            }
            return componentClass;
        }

        public static void Change(string name, string description, Guid parentId, Guid OldId)
        {
            using (UserContext DB = new UserContext())
            {
                ComponentClass componentClass = DB.ComponentClasses.Where(n=>n.Id == OldId).FirstOrDefault();
                componentClass.Name = name;
                componentClass.Description = description;
                componentClass.ComponentClassId = parentId;
                DB.SaveChanges();
            }
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

        public ComponentClass GetParent(Guid Id)
        {
            ComponentClass componentClasses;
            using (UserContext DB = new UserContext())
            {
                componentClasses = DB.ComponentClasses.Where(n => n.Id == Id).FirstOrDefault();
            }
            return componentClasses;
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

        public static void Delete(Guid id)
        {
            DeleteCascade(id);
            using (UserContext DB = new UserContext())
            {
                ComponentClass componentClasses = DB.ComponentClasses.Where(n => n.Id == id).FirstOrDefault();

                if (componentClasses != null)
                {
                TypeElement.DeleteByParentId(componentClasses.Id);
                    DB.ComponentClasses.Remove(componentClasses);
                    DB.SaveChanges();
                }
            }
        }
        public static void DeleteCascade(Guid id)
        {
            using (UserContext DB = new UserContext())
            {
                var componentClasses = DB.ComponentClasses.Where(n => n.ComponentClassId == id).ToList();
                foreach(var componentClass in componentClasses)
                {
                    DeleteCascade(componentClass.Id);
                    TypeElement.DeleteByParentId(componentClass.Id);
                    DB.ComponentClasses.Remove(componentClass);
                    DB.SaveChanges();
                }
            }
        }
    }
}
