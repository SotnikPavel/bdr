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



        public void Add(string name, string description)
        {
            using (UserContext DB = new UserContext())
            {
                Producer producer = new Producer();
                producer.Id = Guid.NewGuid();
                producer.Name = name;
                producer.Description = description;
                DB.Producers.Add(producer);
                DB.SaveChanges();
            }
        }
        public static List<Producer> GetList()
        {
            List<Producer> producer;
            using (UserContext DB = new UserContext())
            {
                producer = DB.Producers.ToList();
            }
            return producer;
        }
    }
}
