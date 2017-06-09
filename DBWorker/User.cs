using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;

namespace DBWorker
{
    public class User
    {
        public static Guid? GetIdByLogin(string login)
        {
            DBModel.User user;
            using (UserContext DB = new UserContext())
            {
                user = DB.Users.Where(n => n.Login == login).FirstOrDefault();
            }
            if (user != null)
            {
                return user.Id;
            }
            else
            {
                return null;
            }
        }

        public static void AddData(Guid userId, string name, string surname, string phone, string portName)
        {
            using (UserContext DB = new UserContext())
            {
                DBModel.User user = DB.Users.Where(n => n.Id == userId).FirstOrDefault();
                user.Name = name;
                user.SurName = surname;
                user.Phone = phone;
                user.PortName = portName;
                DB.SaveChanges();
            }
        }

        public static DBModel.User GetUserById(Guid userId)
        {
            using (UserContext DB = new UserContext())
            {
                DBModel.User user = DB.Users.Where(n => n.Id == userId).FirstOrDefault();
                return user;
            }
        }

        public static string GetUserPortNameById(Guid userId)
        {
            using (UserContext DB = new UserContext())
            {
                DBModel.User user = DB.Users.Where(n => n.Id == userId).FirstOrDefault();
                return user.PortName;
            }
        }

        public static DBModel.User Add(string login)
        {
            Guid? res = GetIdByLogin(login);
            if(res == null)
            {
                using (UserContext DB = new UserContext())
                {
                    DBModel.User user = new DBModel.User();
                    user.Id = Guid.NewGuid();
                    user.Login = login;
                    DB.Users.Add(user);
                    DB.SaveChanges();
                    return user;
                }
            }
            return null;
        }
    }
}
