using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;
using System.Collections.ObjectModel;

namespace DBWorker
{
    public class Storages
    {

        public static Storage GetById(Guid id)
        {
            Storage storage;
            using (UserContext DB = new UserContext())
            {
                storage = DB.Storages.Where(n => n.Id == id).FirstOrDefault();
            }
            return storage;
        }

        public static Storage GetByRfidId(string rfidId)
        {
            Storage storage;
            using (UserContext DB = new UserContext())
            {
                storage = DB.Storages.Where(n => n.RfidId == rfidId).FirstOrDefault();
            }
            return storage;
        }

        public static Guid GetIdByName(string name)
        {
            Storage storage;
            using (UserContext DB = new UserContext())
            {
                storage = DB.Storages.Where(n => n.Name == name).FirstOrDefault();
            }
            return storage.Id;
        }

        public static void Change(string name, string description, string rfidId, Guid parentId, Guid OldId)
        {
            using (UserContext DB = new UserContext())
            {
                Storage storage = DB.Storages.Where(n => n.Id == OldId).FirstOrDefault();
                storage.Name = name;
                storage.Description = description;
                storage.StorageId = parentId;
                storage.RfidId = rfidId;
                DB.SaveChanges();
            }
        }

        public static void Add(Guid userId, string name, string description, Guid parentId, string rfidId)
        {
            using (UserContext DB = new UserContext())
            {
                Storage storage = new Storage();
                storage.UserId = userId;
                storage.Id = Guid.NewGuid();
                storage.Name = name;
                storage.Description = description;
                storage.StorageId = parentId;
                storage.RfidId = rfidId;
                DB.Storages.Add(storage);
                DB.SaveChanges();
            }
        }

        public Storage GetParent(Guid Id)
        {
            Storage storage;
            using (UserContext DB = new UserContext())
            {
                storage = DB.Storages.Where(n => n.Id == Id).FirstOrDefault();
            }
            return storage;
        }


        public ObservableCollection<Storage> GetByParentId(Guid parentId, Guid userId, Guid? ignoreId)
        {
            ObservableCollection<Storage> storages;
            using (UserContext DB = new UserContext())
            {
                if(ignoreId != null)
                {
                    storages = new ObservableCollection<Storage>(DB.Storages.Where(n => n.StorageId == parentId && n.UserId == userId && n.Id != ignoreId.Value).ToList());
                }
                else
                {
                    storages = new ObservableCollection<Storage>(DB.Storages.Where(n => n.StorageId == parentId && n.UserId == userId).ToList());
                }
            }
            return storages;
        }

        public static void Delete(Guid id)
        {
            DeleteCascade(id);
            using (UserContext DB = new UserContext())
            {
                Storage storage = DB.Storages.Where(n => n.Id == id).FirstOrDefault();

                if (storage != null)
                {
                    TypeElement.DeleteByParentId(storage.Id);
                    DB.Storages.Remove(storage);
                    DB.SaveChanges();
                }
            }
        }
        public static void DeleteCascade(Guid id)
        {
            using (UserContext DB = new UserContext())
            {
                var storages = DB.Storages.Where(n => n.StorageId == id).ToList();
                foreach (var storage in storages)
                {
                    DeleteCascade(storage.Id);
                    TypeElement.DeleteByParentId(storage.Id);
                    DB.Storages.Remove(storage);
                    DB.SaveChanges();
                }
            }
        }
    }
}
