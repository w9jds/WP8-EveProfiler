using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveProfiler.BusinessLogic.Character
{
    public class Character
    {
        public string CharacterID { get; set; }
        public Info CharacterInfo { get; set; }
        public byte[] CharacterPort { get; set; }
        public byte[] AlliancePort { get; set; }
        public byte[] CorpPort { get; set; }
    }
}
