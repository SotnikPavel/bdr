using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;
using System.Collections.ObjectModel;

namespace DBWorker
{
    public class ShellTypes
    {
        public static ShellType GetById(Guid id)
        {
            ShellType shellType;
            using (UserContext DB = new UserContext())
            {
                shellType = DB.ShellTypes.Where(n => n.Id == id).FirstOrDefault();
            }
            return shellType;
        }

        public static Guid? GetIdByName(string name)
        {
            ShellType shellType;
            using (UserContext DB = new UserContext())
            {
                shellType = DB.ShellTypes.Where(n => n.Name == name).FirstOrDefault();
            }
            if (shellType != null)
            {
                return shellType.Id;
            }
            else
            {
                return null;
            }
        }
        public static void Change(DBModel.ShellType shellType)
        {
            using (UserContext DB = new UserContext())
            {
                var shellTypeOld = DB.ShellTypes.Where(n => n.Id == shellType.Id).FirstOrDefault();
                shellTypeOld.Name = shellType.Name;
                shellTypeOld.Description = shellType.Description;
                shellTypeOld.PinsQuantity = shellType.PinsQuantity;
                DB.SaveChanges();
            }
        }

        public static void Delete(DBModel.ShellType shellType)
        {
            using (UserContext DB = new UserContext())
            {
                var shellTypeOld = DB.ShellTypes.Where(n => n.Id == shellType.Id).FirstOrDefault();
                DB.ShellTypes.Remove(shellTypeOld);
                DB.SaveChanges();
            }
        }

        public void Add(Guid userId,string name, string description, int pinCount)
        {
            using (UserContext DB = new UserContext())
            {
                ShellType shellType = new ShellType();
                shellType.UserId = userId;
                shellType.Id = Guid.NewGuid();
                shellType.Name = name;
                shellType.Description = description;
                shellType.PinsQuantity = pinCount;
                DB.ShellTypes.Add(shellType);
                DB.SaveChanges();
            }
        }

        public static List<ShellType> GetList()
        {
            List<ShellType> shellTypes;
            using (UserContext DB = new UserContext())
            {
                shellTypes = DB.ShellTypes.Where(n => n.Id != Guid.Empty).ToList();
            }
            return shellTypes;
        }
    }
}
