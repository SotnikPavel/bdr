using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWorker
{
    public class Component
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Class { get; set; }
        public string BodyType { get; set; }
        public Guid ProducerId { get; set; }
        public Guid ShellTypeId { get; set; }
        public Guid ClassId { get; set; }

        public Component()
        {
            
        }

        public void LoadClassId()
        {
            ClassId = DBWorker.TypeElement.GetIdByName(Class);
        }

        public void Load()
        {
            var component = DBWorker.Components.GetById(Id);
            ProducerId = component.ProducerId;
            ShellTypeId = component.ShellTypeId;
            ClassId = component.ComponentClassId;
        }

        public Component(Guid id, string name, string producer, string classE, string bodyType)
        {
            Id = id;
            Name = name;
            Producer = producer;
            Class = classE;
            BodyType = bodyType;
        }
    }
}
