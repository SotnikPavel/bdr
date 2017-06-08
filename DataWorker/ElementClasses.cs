using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DBModel;

namespace DataWorker
{
    public class ElementClasses
    {
        public ObservableCollection<ElementClasses> ElementClassesData { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BaseClassName { get; set; }
        public Guid Id { get; set; }
        private DBWorker.ElementClasses DBWorker = new DBWorker.ElementClasses();

        public void Load(Guid userId)
        {
            ElementClassesData = GetClassesByParentId(Guid.Empty, userId);
        }

        public void BaseClassLoad()
        {
            BaseClassName = DBWorker.GetParent(Id).Name;
        }

        public ElementClasses()
        {

        }

        public ElementClasses(string name, string description, Guid id, ObservableCollection<ElementClasses> ee)
        {
            Name = name;
            Description = description;
            ElementClassesData = ee;
            Id = id;
        }

        private ObservableCollection<ElementClasses> GetClassesByParentId(Guid parentId, Guid userId)
        {
            ObservableCollection<ElementClasses> rc = new ObservableCollection<ElementClasses>();
            var componentClasses = DBWorker.GetByParentId(parentId);
            foreach(var componentClass in componentClasses)
            {
                if(componentClass.Id != Guid.Empty)
                {
                    rc.Add(new ElementClasses(componentClass.Name, componentClass.Description, componentClass.Id, GetClassesByParentId(componentClass.Id, userId)));
                }
            }
            return rc;
        }

    }
}
