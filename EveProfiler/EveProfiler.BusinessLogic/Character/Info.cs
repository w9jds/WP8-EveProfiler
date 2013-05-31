using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveProfiler.BusinessLogic.Character
{
    public class Info
    {
        //Character Info
        public static string name { get; set; }
        public static string race { get; set; }
        public static string bloodline { get; set; }
        public static double accountBalance { get; set; }
        public static double skillPoints { get; set; }
        public static string shipName { get; set; }
        public static string shipTypeID { get; set; }
        public static string shipTypeName { get; set; }
        public static string corporationID { get; set; }
        public static string corporation { get; set; }
        public static DateTime corporationDate { get; set; }
        public static string allianceID { get; set; }
        public static string alliance { get; set; }
        public static DateTime alliancenDate { get; set; }
        public static string lastKnownLocation { get; set; }
        public static double securityStatus { get; set; }
        //employment history here
        public static DateTime cachedUntil { get; set; }
    }
}
