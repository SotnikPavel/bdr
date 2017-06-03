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

        public void Add(string name, string description, int pinCount)
        {
            using (UserContext DB = new UserContext())
            {
                ShellType shellType = new ShellType();
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
                shellTypes = DB.ShellTypes.ToList();
            }
            return shellTypes;
        }
    }
}
