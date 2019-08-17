using System.Collections.Generic;
using SonicHeroes.Utils.DiscordRPC.Heroes.Definitions.Enums;

namespace SonicHeroes.Utils.DiscordRPC.Heroes.Utilities
{
    public class StageNameDictionary
    {
        public static Dictionary<StageID, string> Dictionary = new Dictionary<StageID, string>(128);

        static StageNameDictionary()
        {
            Dictionary[StageID.TestLevel]           = "Test Level";

            Dictionary[StageID.SeasideHill]         = "Seaside Hill";
            Dictionary[StageID.OceanPalace]         = "Ocean Palace";
            Dictionary[StageID.GrandMetropolis]     = "Grand Metropolis";
            Dictionary[StageID.PowerPlant]          = "Power Plant";
            Dictionary[StageID.CasinoPark]          = "Casino Park";
            Dictionary[StageID.BingoHighway]        = "Bingo Highway";
            Dictionary[StageID.RailCanyon]          = "Rail Canyon";
            Dictionary[StageID.BulletStation]       = "Bullet Station";
            Dictionary[StageID.FrogForest]          = "Frog Forest";
            Dictionary[StageID.LostJungle]          = "Lost Jungle";
            Dictionary[StageID.HangCastle]          = "Hang Castle";
            Dictionary[StageID.MysticMansion]       = "Mystic Mansion";
            Dictionary[StageID.EggFleet]            = "Egg Fleet";
            Dictionary[StageID.FinalFortress]       = "Final Fortress";

            Dictionary[StageID.EggHawk]             = "Egg Hawk";
            Dictionary[StageID.TeamBattle1]         = "Team Battle 1";
            Dictionary[StageID.TeamBattle2]         = "Team Battle 2";
            Dictionary[StageID.RobotStorm]          = "Robot Storm";
            Dictionary[StageID.EggEmperor]          = "Egg Emperor";
            Dictionary[StageID.MetalMadness]        = "Metal Madness";
            Dictionary[StageID.MetalOverlord]       = "Metal Overlord";

            Dictionary[StageID.SeaGate]             = "Sea Gate";

            Dictionary[StageID.SeasideCourse]       = "Seaside Course (2P)";
            Dictionary[StageID.CityCourse]          = "City Course (2P)";
            Dictionary[StageID.CasinoCourse]        = "Casino Course (2P)";

            Dictionary[StageID.BonusStage1]         = "Bonus Stage 1";
            Dictionary[StageID.BonusStage2]         = "Bonus Stage 2";
            Dictionary[StageID.BonusStage3]         = "Bonus Stage 3";
            Dictionary[StageID.BonusStage4]         = "Bonus Stage 4";
            Dictionary[StageID.BonusStage5]         = "Bonus Stage 5";
            Dictionary[StageID.BonusStage6]         = "Bonus Stage 6";
            Dictionary[StageID.BonusStage7]         = "Bonus Stage 7";

            Dictionary[StageID.SeasideHill2P]       = "Seaside Hill (2P)";
            Dictionary[StageID.GrandMetropolis2P]   = "Grand Metropolis (2P)";
            Dictionary[StageID.BingoHighway2P]      = "Bingo Highway (2P)";

            Dictionary[StageID.CityTopBattle]       = "City Top (2P)";
            Dictionary[StageID.CasinoRingBattle]    = "Casino Ring (2P)";
            Dictionary[StageID.TurtleShellBattle]   = "Turtle Shell (2P)";

            Dictionary[StageID.EggTreat]            = "Egg Treat (2P)";
            Dictionary[StageID.PinballMatch]        = "Pinball Match (2P)";
            Dictionary[StageID.HotElevator]         = "Hot Elevator (2P)";

            Dictionary[StageID.RoadRock]            = "Road Rock (2P)";
            Dictionary[StageID.MadExpress]          = "Mad Express (2P)";
            Dictionary[StageID.TerrorHall]          = "Terror Hall (2P)";

            Dictionary[StageID.RailCanyonExpert]    = "Rail Canyon (2P)";
            Dictionary[StageID.FrogForestExpert]    = "Frog Forest (2P)";
            Dictionary[StageID.EggFleetExpert]      = "Egg Fleet (2P)";

            Dictionary[StageID.EmeraldChallenge1]   = "Emerald Challenge 1";
            Dictionary[StageID.EmeraldChallenge2]   = "Emerald Challenge 2";
            Dictionary[StageID.EmeraldChallenge3]   = "Emerald Challenge 3";
            Dictionary[StageID.EmeraldChallenge4]   = "Emerald Challenge 4";
            Dictionary[StageID.EmeraldChallenge5]   = "Emerald Challenge 5";
            Dictionary[StageID.EmeraldChallenge6]   = "Emerald Challenge 6";
            Dictionary[StageID.EmeraldChallenge7]   = "Emerald Challenge 7";

            Dictionary[StageID.SpecialStageMultiplayer1] = "Special Stage 1 (2P)";
            Dictionary[StageID.SpecialStageMultiplayer2] = "Special Stage 2 (2P)";
            Dictionary[StageID.SpecialStageMultiplayer3] = "Special Stage 3 (2P)";
        }
    }
}
