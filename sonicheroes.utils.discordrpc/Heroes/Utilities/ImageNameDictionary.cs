using System.Collections.Generic;
using SonicHeroes.Utils.DiscordRPC.Heroes.Definitions.Enums;

namespace SonicHeroes.Utils.DiscordRPC.Heroes.Utilities
{
    public static class ImageNameDictionary
    {
        public static Dictionary<StageID, string> Dictionary = new Dictionary<StageID, string>(128);

        static ImageNameDictionary()
        {
            Dictionary[StageID.TestLevel]              = "testlevel";

            Dictionary[StageID.SeasideHill]            = "seasidehill";
            Dictionary[StageID.OceanPalace]            = "oceanpalace";
            Dictionary[StageID.GrandMetropolis]        = "grandmetropolis";
            Dictionary[StageID.PowerPlant]             = "powerplant";
            Dictionary[StageID.CasinoPark]             = "casinopark";
            Dictionary[StageID.BingoHighway]           = "bingohighway";
            Dictionary[StageID.RailCanyon]             = "railcanyon";
            Dictionary[StageID.BulletStation]          = "bulletstation";
            Dictionary[StageID.FrogForest]             = "frogforest";
            Dictionary[StageID.LostJungle]             = "lostjungle";
            Dictionary[StageID.HangCastle]             = "hangcastle";
            Dictionary[StageID.MysticMansion]          = "mysticmansion";
            Dictionary[StageID.EggFleet]               = "eggfleet";
            Dictionary[StageID.FinalFortress]          = "finalfortress";

            Dictionary[StageID.EggHawk]                = "egghawk";
            Dictionary[StageID.TeamBattle1]            = "teambattle1";
            Dictionary[StageID.TeamBattle2]            = "teambattle2";
            Dictionary[StageID.RobotStorm]             = "robotstorm";
            Dictionary[StageID.EggEmperor]             = "eggemperor";
            Dictionary[StageID.MetalMadness]           = "metalmadness";
            Dictionary[StageID.MetalOverlord]          = "metaloverlord";

            Dictionary[StageID.SeaGate]                = "seagate";

            Dictionary[StageID.SeasideCourse]          = "seasidecourse";
            Dictionary[StageID.CityCourse]             = "citycourse";
            Dictionary[StageID.CasinoCourse]           = "casinocourse";

            Dictionary[StageID.BonusStage1]            = "bonusstage1";
            Dictionary[StageID.BonusStage2]            = "bonusstage2";
            Dictionary[StageID.BonusStage3]            = "bonusstage3";
            Dictionary[StageID.BonusStage4]            = "bonusstage4";
            Dictionary[StageID.BonusStage5]            = "bonusstage5";
            Dictionary[StageID.BonusStage6]            = "bonusstage6";
            Dictionary[StageID.BonusStage7]            = "bonusstage7";

            Dictionary[StageID.SeasideHill2P]          = "seasidehill2p";
            Dictionary[StageID.GrandMetropolis2P]      = "grandmetropolis";
            Dictionary[StageID.BingoHighway2P]         = "bingohighway";

            Dictionary[StageID.CityTopBattle]          = "citytop";
            Dictionary[StageID.CasinoRingBattle]       = "casinoring";
            Dictionary[StageID.TurtleShellBattle]      = "turtleshell";

            Dictionary[StageID.EggTreat]               = "eggtreat";
            Dictionary[StageID.PinballMatch]           = "pinballmatch";
            Dictionary[StageID.HotElevator]            = "hotelevator";

            Dictionary[StageID.RoadRock]               = "roadrock";
            Dictionary[StageID.MadExpress]             = "madexpress";
            Dictionary[StageID.TerrorHall]             = "terrorhall";

            Dictionary[StageID.RailCanyonExpert]       = "railcanyon";
            Dictionary[StageID.FrogForestExpert]       = "frogforest";
            Dictionary[StageID.EggFleetExpert]         = "eggfleet";

            Dictionary[StageID.EmeraldChallenge1]      = "bonusstage1";
            Dictionary[StageID.EmeraldChallenge2]      = "bonusstage2";
            Dictionary[StageID.EmeraldChallenge3]      = "bonusstage3";
            Dictionary[StageID.EmeraldChallenge4]      = "bonusstage4";
            Dictionary[StageID.EmeraldChallenge5]      = "bonusstage5";
            Dictionary[StageID.EmeraldChallenge6]      = "bonusstage6";
            Dictionary[StageID.EmeraldChallenge7]      = "bonusstage7";

            Dictionary[StageID.SpecialStageMultiplayer1] = "bonusstage1";
            Dictionary[StageID.SpecialStageMultiplayer2] = "bonusstage4";
            Dictionary[StageID.SpecialStageMultiplayer3] = "bonusstage7";
        }
    }
}
