using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;

namespace DBWorker
{
    public class ParsingOtherFields
    {
        public static void Change(Guid id, string value)
        {
            using (UserContext DB = new UserContext())
            {
                var typeElementFieldComponents = DB.ParsingOtherFields.Where(n => n.Id == id).First();
                typeElementFieldComponents.Value = value;
                DB.SaveChanges();
            }
        }

        public static List<ParsingOtherField> GetListByParsingComponentsId(Guid parsingComponentsId)
        {
            using (UserContext DB = new UserContext())
            {
                return DB.ParsingOtherFields.Where(n => n.ParsingComponentsId == parsingComponentsId).ToList();
            }
        }

        public static void Add(Guid parsingId, Guid typeElementId)
        {
            var typeElementFieldsList =  TypeElementFields.GetList(typeElementId);
            using (UserContext DB = new UserContext())
            {
                foreach(var typeElementFields in typeElementFieldsList)
                {
                    DB.ParsingOtherFields.Add(new ParsingOtherField(Guid.NewGuid(), typeElementFields.Id, parsingId));
                }
                DB.SaveChanges();
            }
        }
    }
}
