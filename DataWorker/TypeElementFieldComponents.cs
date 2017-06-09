using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWorker
{
    public static class TypeElementFieldComponents
    {
        public static List<TypeElementFieldComponent> GetList(Guid componentId)
        {
            List<TypeElementFieldComponent> listTypeElementFieldComponent = new List<TypeElementFieldComponent>();
            var typeElementFieldComponentsList = DBWorker.TypeElementFieldComponents.GetListByClassId(componentId);
            foreach(var t in typeElementFieldComponentsList)
            {
                listTypeElementFieldComponent.Add(new TypeElementFieldComponent(t.Id, DBWorker.TypeElementFields.GetNameById(t.TypeElementFieldId), t.Value));
            }
            return listTypeElementFieldComponent;
        }

        public static List<TypeElementFieldComponent> GetListComponents(Guid componentsType)
        {
            List<TypeElementFieldComponent> listTypeElementFieldComponent = new List<TypeElementFieldComponent>();
            List<DBModel.ParsingOtherField> listTypeElementField = DBWorker.ParsingOtherFields.GetListByParsingComponentsId(componentsType);
            foreach (var t in listTypeElementField)
            {
                listTypeElementFieldComponent.Add(new TypeElementFieldComponent(t.Id, DBWorker.TypeElementFields.GetNameById(t.TypeElementFieldId), t.Value));
            }
            return listTypeElementFieldComponent;
        }
    }
}
