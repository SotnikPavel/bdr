using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;


namespace DBWorker
{
    public class Producers
    {
        public static Producer GetById(Guid id)
        {
            Producer producer;
            using (UserContext DB = new UserContext())
            {
                producer = DB.Producers.Where(n => n.Id == id).FirstOrDefault();
            }
            return producer;
        }

        public static Guid? GetIdByName(string name)
        {
            Producer producer;
            using (UserContext DB = new UserContext())
            {
                producer = DB.Producers.Where(n => n.Name == name).FirstOrDefault();
            }
            if(producer != null)
            {
                return producer.Id;
            }
            else
            {
                return null;
            }
        }

        public void Add(Guid userId, string name, string description)
        {
            using (UserContext DB = new UserContext())
            {
                Producer producer = new Producer();
                producer.UserId = userId;
                producer.Id = Guid.NewGuid();
                producer.Name = name;
                producer.Description = description;
                DB.Producers.Add(producer);
                DB.SaveChanges();
            }
        }
        public static void Delete(DBModel.Producer producter)
        {
            using (UserContext DB = new UserContext())
            {
                var producterDel = DB.Producers.Where(n => n.Id == producter.Id).First();
                DB.Producers.Remove(producterDel);
                DB.SaveChanges();
            }
        }
        public static void Change(DBModel.Producer producter)
        {
            using (UserContext DB = new UserContext())
            {
                var producerOld = DB.Producers.Where(n => n.Id == producter.Id).FirstOrDefault();
                producerOld.Name = producter.Name;
                producerOld.Description = producter.Description;
                DB.SaveChanges();
            }
        }
        public static List<Producer> GetList()
        {
            List<Producer> producer;
            using (UserContext DB = new UserContext())
            {
                producer = DB.Producers.Where(n => n.Id != Guid.Empty).ToList();
            }
            return producer;
        }
    }
}
