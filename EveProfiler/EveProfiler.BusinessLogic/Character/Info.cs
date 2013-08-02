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
        public string characterName { get; set; }
        public string race { get; set; }
        public string bloodline { get; set; }
        public DateTime nextTrainingEnds { get; set; }
        public double accountBalance { get; set; }
        public double skillPoints { get; set; }
        public string shipName { get; set; }
        public string shipTypeID { get; set; }
        public string shipTypeName { get; set; }
        public string corporationID { get; set; }
        public string corporation { get; set; }
        public DateTime corporationDate { get; set; }
        public string allianceID { get; set; }
        public string alliance { get; set; }
        public DateTime allianceDate { get; set; }
        public string lastKnownLocation { get; set; }
        public double securityStatus { get; set; }
        //employment history here
        public DateTime cachedUntil { get; set; }

    }
}
