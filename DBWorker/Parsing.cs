using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;
using System.Collections.ObjectModel;

namespace DBWorker
{
    public class Parsing
    {
        public static Guid Add(string StartUrl, string Name, string NextUrl, string PathToElementPage, string PathToName, Guid ComponentsClassId, string PathToProducter, string PathToShellType)
        {
            using (UserContext DB = new UserContext())
            {
                ParsingComponents parsingComponents = new ParsingComponents();
                parsingComponents.Id = Guid.NewGuid();
                parsingComponents.Name = Name;
                parsingComponents.StartUrl = StartUrl;
                parsingComponents.NextUrl = NextUrl;
                parsingComponents.PathToElementPage = PathToElementPage;
                parsingComponents.PathToName = PathToName;
                parsingComponents.ComponentsClassId = ComponentsClassId;
                parsingComponents.PathToProducter = PathToProducter;
                parsingComponents.PathToShellType = PathToShellType;
                DB.ParsingComponents.Add(parsingComponents);
                DB.SaveChanges();
                return parsingComponents.Id;
            }
        }


        public static void Delete(string name)
        {
            using (UserContext DB = new UserContext())
            {
                DBModel.ParsingComponents pc = DB.ParsingComponents.Where(n => n.Name == name).FirstOrDefault();
                DB.ParsingComponents.Remove(pc);
                DB.SaveChanges();
            }
        }

        public static ObservableCollection<string> Load()
        {
            ObservableCollection<string> parsingTeamplateCollection = new ObservableCollection<string>();
            using (UserContext DB = new UserContext())
            {
                var teamplateCollection = DB.ParsingComponents.ToList();
                foreach(var teamplateCollectionItem in teamplateCollection)
                {
                    parsingTeamplateCollection.Add(teamplateCollectionItem.Name);
                }
            }
            return parsingTeamplateCollection;
        }

        public static ParsingComponents GetByName(string name)
        {
            using (UserContext DB = new UserContext())
            {
                var teamplateCollection = DB.ParsingComponents.Where(n => n.Name == name).FirstOrDefault();
                if(teamplateCollection != null)
                {
                    return teamplateCollection;
                }
                else
                {
                    return null;
                }
            }
        }

        

    }
}
