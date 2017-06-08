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
        public ObservableCollection<Component> GetList(Guid userId)
        {
            ObservableCollection<Component> componentCollection = new ObservableCollection<Component>();

            DBWorker.Components dw = new DBWorker.Components();
            var componentsList = dw.GetList(userId);
            foreach(var component in componentsList)
            {
                string producterName = DBWorker.Producers.GetById(component.ProducerId).Name;
                string className = DBWorker.TypeElement.GetNameById(component.ComponentClassId);
                string typeName = DBWorker.ShellTypes.GetById(component.ShellTypeId).Name;
                componentCollection.Add(new Component(component.Id, component.Name, producterName, className, typeName));
            }

            return componentCollection;
        }
    }
}
