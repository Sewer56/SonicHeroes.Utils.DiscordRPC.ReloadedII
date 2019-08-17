using System.Collections.Generic;
using SonicHeroes.Utils.DiscordRPC.Heroes.Definitions.Enums;

namespace SonicHeroes.Utils.DiscordRPC.Heroes.Utilities
{
    public class TeamNameDictionary
    {
        public static Dictionary<Team, string> Dictionary = new Dictionary<Team, string>(128);

        static TeamNameDictionary()
        {
            Dictionary[Team.Sonic]      = "Sonic";
            Dictionary[Team.Dark]       = "Dark";
            Dictionary[Team.Chaotix]    = "Chaotix";
            Dictionary[Team.Rose]       = "Rose";
            Dictionary[Team.ForEDIT]    = "Foredit";
        }
    }
}
