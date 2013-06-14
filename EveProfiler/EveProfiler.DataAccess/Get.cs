
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EveProfiler.DataAccess
{
    public class Get
    {
        public void getCharacterList()
        {
            List<BusinessLogic.Character.Character> Characters = new List<BusinessLogic.Character.Character>();

            List<Core.Parameters> Parms = new List<Core.Parameters>();
            Parms.Add(new Core.Parameters { ParamName = "keyid", ParamValue = "1996957" });
            Parms.Add(new Core.Parameters { ParamName = "vCode", ParamValue = "I6YLp1vVB0KYAir2B3Z4mDIPtZrFHlpeysYYSaxGkjV4rO820NpTOBustmNsoEA4" });

            Core.ApiCalls get = new Core.ApiCalls();
            get.getCall(ApiStrings.ApiUri, ApiStrings.ListCharacters, Parms);

            get.ApiResponded += new Core.ApiCalls.getResponded(Response =>
            {
                Characters = parseCharacterList(Response);

                for (int i = 0; i < Characters.Count; i++)
                {
                    getCharacterInfo(Characters[i]);
                }
            });

            

        }

        public void getCharacterInfo(BusinessLogic.Character.Character Character)
        {
            List<BusinessLogic.Character.Character> Characters = new List<BusinessLogic.Character.Character>();

            List<Core.Parameters> Parms = new List<Core.Parameters>();
            Parms.Add(new Core.Parameters { ParamName = "keyid", ParamValue = "1996957" });
            Parms.Add(new Core.Parameters { ParamName = "vCode", ParamValue = "I6YLp1vVB0KYAir2B3Z4mDIPtZrFHlpeysYYSaxGkjV4rO820NpTOBustmNsoEA4" });
            Parms.Add(new Core.Parameters { ParamName = "characterID", ParamValue = Character.CharacterID });

            Core.ApiCalls get = new Core.ApiCalls();
            get.getCall(ApiStrings.ApiUri, ApiStrings.CharacterInfo, Parms);

            get.ApiResponded += new Core.ApiCalls.getResponded(Response =>
                {
                    parseCharacterInfo(Response);
                });

        }
        private List<BusinessLogic.Character.Character> parseCharacterList(string xml)
        {

            XDocument doc = XDocument.Parse(xml);

            var m = doc.Descendants("row").ToList();

            List<BusinessLogic.Character.Character> Characters = doc.Descendants("row").Select(x => new BusinessLogic.Character.Character
            {
                CharacterID = x.Attribute("characterID").Value
            }).ToList();

            return Characters;

        }

        private void parseCharacterInfo(string xml)
        {
            XDocument doc = XDocument.Parse(xml);

            BusinessLogic.Character.Info CharacterInfo = doc.Descendants("result").Select(x => new BusinessLogic.Character.Info
            {
                name = x.Element("name").Value,
                accountBalance = double.Parse(x.Element("accountBalance").Value),
                alliance = x.Element("alliance").Value,
                allianceID = x.Element("allianceID").Value,
                allianceDate = DateTime.Parse(x.Element("allianceDate").Value),
                bloodline = x.Element("bloodline").Value,
                corporation = x.Element("corporation").Value,
                corporationDate = DateTime.Parse(x.Element("corporationDate").Value),
                corporationID = x.Element("corporationID").Value,
                lastKnownLocation = x.Element("lastKnownLocation").Value,
                race = x.Element("race").Value,
                securityStatus = Double.Parse(x.Element("securityStatus").Value),
                shipName = x.Element("shipName").Value,
                shipTypeID = x.Element("shipTypeID").Value,
                shipTypeName = x.Element("shipTypeName").Value,
                skillPoints = Double.Parse(x.Element("skillPoints").Value)

            }).ToList().ElementAt(0);


        }
    }
}
