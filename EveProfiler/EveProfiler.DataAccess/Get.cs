
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
            Parms.Add(new Core.Parameters { name = "keyid", value = "1996957" });
            Parms.Add(new Core.Parameters { name = "vCode", value = "I6YLp1vVB0KYAir2B3Z4mDIPtZrFHlpeysYYSaxGkjV4rO820NpTOBustmNsoEA4" });

            Core.ApiCalls.getXml(@"/account/Characters.xml.aspx", Parms, );


            

        }

        public void getCharacterInfo(int CharacterID)
        {
            List<BusinessLogic.Character.Character> Characters = new List<BusinessLogic.Character.Character>();

            List<Core.Parameters> Parms = new List<Core.Parameters>();
            Parms.Add(new Core.Parameters { name = "keyid", value = "1996957" });
            Parms.Add(new Core.Parameters { name = "vCode", value = "I6YLp1vVB0KYAir2B3Z4mDIPtZrFHlpeysYYSaxGkjV4rO820NpTOBustmNsoEA4" });
            Parms.Add(new Core.Parameters { name = "characterID", value = CharacterID.ToString() });

            Core.ApiCalls.getXml(@"/eve/CharacterInfo.xml.aspx", Parms, );



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



//private static string Api_Uri = @"https://api.eveonline.com";
//private static string Account_Status = @"/account/AccountStatus.xml.aspx";
//private static string API_Key_Info = @"/account/APIKeyInfo.xml.aspx";
//private static string Account_Balance = @"/char/AccountBalance.xml.aspx";
//private static string Asset_List = @"/char/AssetList.xml.aspx";
//private static string Cal_Event_Attendees = @"/char/CalendarEventAttendees.xml.aspx";
//private static string Character_Sheet = @"/char/CharacterSheet.xml.aspx";
//private static string Contact_List = @"/char/ContactList.xml.aspx";
//private static string Contact_Notif = @"/char/ContactNotifications.xml.aspx";
//private static string Contacts = @"/char/Contracts.xml.aspx";
//private static string Contract_Items = @"/char/ContractItems.xml.aspx";
//private static string Contract_Bids = @"/char/ContractBids.xml.aspx";
//private static string Factional_Warfare_Stats = @"/char/FacWarStats.xml.aspx";
//private static string Industry_Jobs = @"/char/IndustryJobs.xml.aspx";
//private static string Kill_Mails = @"/char/Killlog.xml.aspx";
//private static string Locations = @"/char/Locations.xml.aspx";
//private static string Mail_Bodies = @"/char/MailBodies.xml.aspx";
//private static string Mailing_Lists = @"/char/MailingLists.xml.aspx";
//private static string Mail_Mess_Headers = @"/char/MailMessages.xml.aspx";
//private static string Market_Orders = @"/char/MarketOrders.xml.aspx";
//private static string Medals = @"/char/Medals.xml.aspx";
//private static string Notifications = @"/char/Notifications.xml.aspx";
//private static string Notification_Text = @"/char/NotificationTexts.xml.aspx";
//private static string Research = @"/char/Research.xml.aspx";
//private static string Skill_in_Training = @"/char/SkillInTraining.xml.aspx";
//private static string Skill_Queue = @"/char/SkillQueue.xml.aspx";
//private static string NPC_Standings = @"/char/Standings.xml.aspx";
//private static string Upcoming_Cal_Events = @"/char/UpcomingCalendarEvents.xml.aspx";
//private static string Wallet_Journal = @"/char/WalletJournal.xml.aspx";
//private static string Wallet_Transactions = @"/char/WalletTransactions.xml.aspx";

//private static string Character_Portrait = @"http://image.eveonline.com/Character/";
//private static string Corp_Logo = @"http://image.eveonline.com/Corporation/";
//private static string Alliance_Logo = @"http://image.eveonline.com/Alliance/";

//public static string CharacterInfo { get { return Character_Info; } }
//public static string ApiUri { get { return Api_Uri; } }
//public static string AccountStatus { get { return Account_Status; } }
//public static string APIKeyInfo { get { return API_Key_Info; } }
//public static string ListCharacters { get { return List_Characters; } }
//public static string AssetList { get { return Asset_List; } }
//public static string CalEventAttendees { get { return Cal_Event_Attendees; } }
//public static string CharacterSheet { get { return Character_Sheet; } }
//public static string ContactList { get { return Contact_List; } }
//public static string ContactNotif { get { return Contact_Notif; } }
//public static string MyContacts { get { return Contacts; } }
//public static string ContractItems { get { return Contract_Items; } }
//public static string ContractBids { get { return Contract_Bids; } }
//public static string FactionalWarfareStats { get { return Factional_Warfare_Stats; } }
//public static string IndustryJobs { get { return Industry_Jobs; } }
//public static string KillMails { get { return Kill_Mails; } }
//public static string MyLocations { get { return Locations; } }
//public static string MailBodies { get { return Mail_Bodies; } }
//public static string MailingLists { get { return Mailing_Lists; } }
//public static string MailMessHeaders { get { return Mail_Mess_Headers; } }
//public static string MarketOrders { get { return Market_Orders; } }
//public static string MyMedals { get { return Medals; } }
//public static string MyNotifications { get { return Notifications; } }
//public static string NotificationText { get { return Notification_Text; } }
//public static string MyResearch { get { return Research; } }
//public static string SkillinTraining { get { return Skill_in_Training; } }
//public static string SkillQueue { get { return Skill_Queue; } }
//public static string NPCStandings { get { return NPC_Standings; } }
//public static string UpcomingCalEvents { get { return Upcoming_Cal_Events; } }
//public static string WalletJournal { get { return Wallet_Journal; } }
//public static string WalletTransactions { get { return Wallet_Transactions; } }

//public static string CharacterPortrait { get { return Character_Portrait; } }
//public static string CorpLogo { get { return Corp_Logo; } }
//public static string AllianceLogo { get { return Alliance_Logo; } }
