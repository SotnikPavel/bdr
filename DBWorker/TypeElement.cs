using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;
using System.Collections.ObjectModel;

namespace DBWorker
{
    public class TypeElement
    {
        public TypeElement()
        {

        }

        public static Guid GetIdByName(string Name)
        {
            using (UserContext DB = new UserContext())
            {
                var typeElement = DB.TypeElements.Where(n => n.Name == Name).FirstOrDefault();
                return typeElement.Id;
            }
        }

        public static string GetNameById(Guid Id)
        {
            using (UserContext DB = new UserContext())
            {
                var typeElement = DB.TypeElements.Where(n => n.Id == Id).FirstOrDefault();
                return typeElement.Name;
            }
        }

        public static DBModel.TypeElement GetTypeElementById(Guid Id)
        {
            using (UserContext DB = new UserContext())
            {
                var typeElement = DB.TypeElements.Where(n => n.Id == Id).FirstOrDefault();
                return typeElement;
            }
        }

        public static void Change(string name, string description, Guid parentId, Guid OldId)
        {
            using (UserContext DB = new UserContext())
            {
                DBModel.TypeElement componentClass = DB.TypeElements.Where(n => n.Id == OldId).FirstOrDefault();
                componentClass.Name = name;
                componentClass.Description = description;
                componentClass.ComponentClassId = parentId;
                DB.SaveChanges();
            }
        }

        public ObservableCollection<DBModel.TypeElement> GetByParentId(Guid parentId)
        {
            ObservableCollection<DBModel.TypeElement> componentClasses;
            using (UserContext DB = new UserContext())
            {
                componentClasses = new ObservableCollection<DBModel.TypeElement>(DB.TypeElements.Where(n => n.ComponentClassId == parentId).ToList());
            }
            return componentClasses;
        }

        public List<DBModel.TypeElement> GetList()
        {
            List<DBModel.TypeElement> componentClasses;
            using (UserContext DB = new UserContext())
            {
                componentClasses = DB.TypeElements.Where(n => n.Id != Guid.Empty).ToList();
            }
            return componentClasses;
        }

        public static void Add(string name, string description, Guid elementClassId)
        {
            using (UserContext DB = new UserContext())
            {
                DBModel.TypeElement typeElementClass = new DBModel.TypeElement();
                typeElementClass.Id = Guid.NewGuid();
                typeElementClass.Name = name;
                typeElementClass.Description = description;
                typeElementClass.ComponentClassId = elementClassId;
                DB.TypeElements.Add(typeElementClass);
                DB.SaveChanges();
            }
        }

        public static void DeleteByParentId(Guid ParentId)
        {
            using (UserContext DB = new UserContext())
            {
                var typeElementClasses = DB.TypeElements.Where(n => n.ComponentClassId == ParentId).ToList();
                foreach(var typeElementClass in typeElementClasses)
                {
                    DB.TypeElements.Remove(typeElementClass);
                    DB.SaveChanges();
                }
            }
        }

        public static void Delete(Guid id)
        {
            using (UserContext DB = new UserContext())
            {
                DBModel.TypeElement typeElementClass = DB.TypeElements.Where(n => n.Id == id).FirstOrDefault();
                DB.TypeElements.Remove(typeElementClass);
                DB.SaveChanges();
            }
        }
    }
}
