using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveProfiler.Classes
{
    public static class ApiStrings
    {
        private static string Api_Uri = @"https://api.eveonline.com";
        private static string Account_Status = @"/account/AccountStatus.xml.aspx";
        private static string API_Key_Info = @"/account/APIKeyInfo.xml.aspx";
        private static string List_Characters = @"/account/Characters.xml.aspx";
        private static string Account_Balance = @"/char/AccountBalance.xml.aspx";
        private static string Asset_List = @"/char/AssetList.xml.aspx";
        private static string Cal_Event_Attendees = @"/char/CalendarEventAttendees.xml.aspx";
        private static string Character_Sheet = @"/char/CharacterSheet.xml.aspx";
        private static string Contact_List = @"/char/ContactList.xml.aspx";
        private static string Contact_Notif = @"/char/ContactNotifications.xml.aspx";
        private static string Contacts = @"/char/Contracts.xml.aspx";
        private static string ContractItems = @"/char/ContractItems.xml.aspx";
        private static string ContractBids = @"/char/ContractBids.xml.aspx";
        private static string Factional_Warfare_Stats = @"/char/FacWarStats.xml.aspx";
        private static string Industry_Jobs = @"/char/IndustryJobs.xml.aspx";
        private static string KillMails = @"/char/Killlog.xml.aspx";
        private static string Locations = @"/char/Locations.xml.aspx";
        private static string Mail_Bodies = @"/char/MailBodies.xml.aspx";
        private static string Mailing_Lists = @"/char/MailingLists.xml.aspx";
        private static string MailMessHeaders = @"/char/MailMessages.xml.aspx";
        private static string Market_Orders = @"/char/MarketOrders.xml.aspx";
        private static string Medals = @"/char/Medals.xml.aspx";
        private static string Notifications = @"/char/Notifications.xml.aspx";
        private static string Notification_Text = @"/char/NotificationTexts.xml.aspx";
        private static string Research = @"/char/Research.xml.aspx";
        private static string Skill_in_Training = @"/char/SkillInTraining.xml.aspx";
        private static string Skill_Queue = @"/char/SkillQueue.xml.aspx";
        private static string NPC_Standings = @"/char/Standings.xml.aspx";
        private static string Upcoming_Cal_Events = @"/char/UpcomingCalendarEvents.xml.aspx";
        private static string Wallet_Journal = @"/char/WalletJournal.xml.aspx";
        private static string Wallet_Transactions = @"/char/WalletTransactions.xml.aspx";

        private static string Character_Portrait = @"http://image.eveonline.com/Character/";
        private static string Corp_Logo = @"http://image.eveonline.com/Corporation/";
        private static string Alliance_Logo = @"http://image.eveonline.com/Alliance/";

        public static string ApiUri { get { return Api_Uri; } }
        public static string AccountStatus { get { return Account_Status; } }
        public static string APIKeyInfo { get { return API_Key_Info; } }
        public static string ListCharacters { get { return List_Characters; } }
        


    }
}
