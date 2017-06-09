using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;

namespace DBWorker
{
    public class Availability
    {
        public static List<DBModel.Availability> GetAvailabilitysListByComponentId(Guid componentId)
        {
            List<DBModel.Availability> availabilitys;
            using (UserContext DB = new UserContext())
            {
                availabilitys = DB.Availabilitys.Where(n => n.ComponentId == componentId).ToList();
            }
            return availabilitys;
        }

        public static List<DBModel.Availability> GetAvailabilitysListByStorageId(Guid storageId)
        {
            List<DBModel.Availability> availabilitys;
            using (UserContext DB = new UserContext())
            {
                availabilitys = DB.Availabilitys.Where(n => n.StorageId == storageId).ToList();
            }
            return availabilitys;
        }

        public static void Add(Guid storageId, Guid componentId, int count)
        {
            using (UserContext DB = new UserContext())
            {
                DBModel.Availability availability = new DBModel.Availability();
                availability.Id = Guid.NewGuid();
                availability.StorageId = storageId;
                availability.ComponentId = componentId;
                availability.Count = count;
                DB.Availabilitys.Add(availability);
                DB.SaveChanges();
            }
        }

        public static void Delete(string storageName, Guid componentId)
        {
            using (UserContext DB = new UserContext())
            {
                DBModel.Availability availability = DB.Availabilitys.Where(n => n.StorageId == Storages.GetIdByName(storageName) && n.ComponentId == componentId).First();
                DB.Availabilitys.Remove(availability);
                DB.SaveChanges();
            }
        }
        public static void Change(string storageName, int count, Guid componentId, string storageNameOld)
        {
            using (UserContext DB = new UserContext())
            {
                Guid storageOldId = Storages.GetIdByName(storageNameOld);
                DBModel.Availability availability = DB.Availabilitys.Where(n => n.ComponentId == componentId && n.StorageId == storageOldId).FirstOrDefault();
                availability.StorageId = Storages.GetIdByName(storageName);
                availability.Count = count;
                DB.SaveChanges();
            }
        }
    }
}
