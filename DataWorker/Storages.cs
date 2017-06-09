using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DataWorker
{
    public class Storages
    {
        public ObservableCollection<Storages> StoragesData { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RfidId { get; set; }
        public string BaseStorageName { get; set; }
        public Guid Id { get; set; }
        private DBWorker.Storages DBWorker = new DBWorker.Storages();

        public void Load(Guid userId, Guid? ignoreId = null)
        {
            StoragesData = GetClassesByParentId(Guid.Empty, userId, ignoreId);
        }

        public void BaseClassLoad()
        {
            BaseStorageName = DBWorker.GetParent(Id).Name;
        }

        public Storages()
        {

        }

        public Storages(string name, string description, string rfidId, Guid id, ObservableCollection<Storages> ee)
        {
            Name = name;
            Description = description;
            StoragesData = ee;
            RfidId = rfidId;
            Id = id;
        }

        private ObservableCollection<Storages> GetClassesByParentId(Guid parentId, Guid userId, Guid? ignoreId)
        {
            ObservableCollection<Storages> rc = new ObservableCollection<Storages>();
            var componentClasses = DBWorker.GetByParentId(parentId, userId, ignoreId);
            foreach (var componentClass in componentClasses)
            {
                if (componentClass.Id != Guid.Empty)
                {
                    rc.Add(new Storages(componentClass.Name, componentClass.Description, componentClass.RfidId, componentClass.Id, GetClassesByParentId(componentClass.Id, userId, ignoreId)));
                }
            }
            return rc;
        }

    }
}
