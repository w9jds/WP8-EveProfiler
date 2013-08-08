using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EveProfiler.DataAccess
{
    public static class Parse
    {

        public static List<BusinessLogic.Character.Character> CharacterList(string xml)
        {

            XDocument doc = XDocument.Parse(xml);

            var m = doc.Descendants("row").ToList();

            List<BusinessLogic.Character.Character> Characters = doc.Descendants("row").Select(x => new BusinessLogic.Character.Character
            {
                CharacterID = x.Attribute("characterID").Value
            }).ToList();

            return Characters;

        }

        public static BusinessLogic.Character.Info CharacterInfo(string xml)
        {
            XDocument doc = XDocument.Parse(xml);

            BusinessLogic.Character.Info thisCharacter = doc.Descendants("result").Select(x => new BusinessLogic.Character.Info
            {
                characterName = x.Element("characterName").Value,
                race = x.Element("race").Value,
                bloodline = x.Element("bloodline").Value,
                accountBalance = double.Parse(x.Element("accountBalance").Value),
                skillPoints = double.Parse(x.Element("skillPoints").Value),
                shipName = x.Element("shipName").Value,
                shipTypeID = x.Element("shipTypeID").Value,
                shipTypeName = x.Element("shipTypeName").Value,
                corporationID = x.Element("corporationID").Value,
                corporation = x.Element("corporation").Value,
                corporationDate = DateTime.Parse(x.Element("corporationDate").Value),
                lastKnownLocation = x.Element("lastKnownLocation").Value,
                securityStatus = double.Parse(x.Element("securityStatus").Value)
            }).ToList().ElementAt(0);

            return thisCharacter;
        }


    }
}
