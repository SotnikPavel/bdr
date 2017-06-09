using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWorker
{
    public class ComponentStorage
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public ComponentStorage()
        {

        }
        public ComponentStorage(string name, int count)
        {
            Name = name;
            Count = count;
        }
    }
}
