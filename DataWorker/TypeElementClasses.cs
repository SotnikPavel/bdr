using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DBWorkerClassS = DBWorker.TypeElement;

namespace DataWorker
{
    public class TypeElementClasses
    {
        public ObservableCollection<TypeElementClasses> TypeElementClassesData { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BaseClassName { get; set; }
        public Guid BaseClassId { get; set; }
        public Guid Id { get; set; }
        private DBWorker.TypeElement DBWorker = new DBWorker.TypeElement();
        private DBWorker.ElementClasses DBWorkerClass = new DBWorker.ElementClasses();

        public void Load(Guid? ParentId)
        {
            TypeElementClassesData = GetClassesByParentId(ParentId == null ? Guid.Empty : ParentId.Value);
        }

        public TypeElementClasses()
        {

        }

        public void BaseClassLoad()
        {
            var typeElementClass = DBWorkerClassS.GetTypeElementById(Id);
            BaseClassName = DBWorkerClass.GetParent(typeElementClass.ComponentClassId).Name;
            BaseClassId = DBWorkerClass.GetParent(typeElementClass.ComponentClassId).Id;
        }

        public TypeElementClasses(string name, string description, Guid id, ObservableCollection<TypeElementClasses> ee)
        {
            Name = name;
            Description = description;
            TypeElementClassesData = ee;
            Id = id;
        }

        private ObservableCollection<TypeElementClasses> GetClassesByParentId(Guid parentId)
        {
            ObservableCollection<TypeElementClasses> rc = new ObservableCollection<TypeElementClasses>();
            var componentClasses = DBWorker.GetByParentId(parentId);
            foreach (var componentClass in componentClasses)
            {
                if (componentClass.Id != Guid.Empty)
                {
                    rc.Add(new TypeElementClasses(componentClass.Name, componentClass.Description, componentClass.Id, GetClassesByParentId(componentClass.Id)));
                }
            }
            return rc;
        }

    }
}
