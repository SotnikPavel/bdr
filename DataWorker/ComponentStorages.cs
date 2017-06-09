using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWorker
{
    public class ComponentStorages
    {
        public static List<ComponentStorage> GetList(Guid componentId)
        {
            List<ComponentStorage> componentStorages = new List<ComponentStorage>();
            var availabilitysList = DBWorker.Availability.GetAvailabilitysListByComponentId(componentId);
            foreach(var availability in availabilitysList)
            {
                componentStorages.Add(new ComponentStorage(DBWorker.Storages.GetById(availability.StorageId).Name, availability.Count));
            }
            return componentStorages;
        }
    }
}
