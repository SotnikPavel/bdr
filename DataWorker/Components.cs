using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DataWorker
{
    public class Components
    {
        public ObservableCollection<Component> GetList()
        {
            ObservableCollection<Component> componentCollection = new ObservableCollection<Component>();

            DBWorker.Components dw = new DBWorker.Components();
            var componentsList = dw.GetList();
            foreach(var component in componentsList)
            {
                string producterName = DBWorker.Producers.GetById(component.ProducerId).Name;
                string className = DBWorker.ElementClasses.GetById(component.ComponentClassId).Name;
                string typeName = DBWorker.ShellTypes.GetById(component.ShellTypeId).Name;
                componentCollection.Add(new Component(component.Id, component.Name, producterName, className, typeName));
            }

            return componentCollection;
        }
    }
}
