using System.Collections.Generic;
using Heroes.SDK.Definitions.Enums;

namespace SonicHeroes.Utils.DiscordRPC.Heroes.Utilities
{
    public static class ImageNameDictionary
    {
        public static Dictionary<Stage, string> Dictionary = new Dictionary<Stage, string>(128);

        static ImageNameDictionary()
        {
            Dictionary[Stage.TestLevel]              = "testlevel";

            Dictionary[Stage.SeasideHill]            = "seasidehill";
            Dictionary[Stage.OceanPalace]            = "oceanpalace";
            Dictionary[Stage.GrandMetropolis]        = "grandmetropolis";
            Dictionary[Stage.PowerPlant]             = "powerplant";
            Dictionary[Stage.CasinoPark]             = "casinopark";
            Dictionary[Stage.BingoHighway]           = "bingohighway";
            Dictionary[Stage.RailCanyon]             = "railcanyon";
            Dictionary[Stage.BulletStation]          = "bulletstation";
            Dictionary[Stage.FrogForest]             = "frogforest";
            Dictionary[Stage.LostJungle]             = "lostjungle";
            Dictionary[Stage.HangCastle]             = "hangcastle";
            Dictionary[Stage.MysticMansion]          = "mysticmansion";
            Dictionary[Stage.EggFleet]               = "eggfleet";
            Dictionary[Stage.FinalFortress]          = "finalfortress";

            Dictionary[Stage.EggHawk]                = "egghawk";
            Dictionary[Stage.TeamBattle1]            = "teambattle1";
            Dictionary[Stage.TeamBattle2]            = "teambattle2";
            Dictionary[Stage.RobotStorm]             = "robotstorm";
            Dictionary[Stage.EggEmperor]             = "eggemperor";
            Dictionary[Stage.MetalMadness]           = "metalmadness";
            Dictionary[Stage.MetalOverlord]          = "metaloverlord";

            Dictionary[Stage.SeaGate]                = "seagate";

            Dictionary[Stage.SeasideCourse]          = "seasidecourse";
            Dictionary[Stage.CityCourse]             = "citycourse";
            Dictionary[Stage.CasinoCourse]           = "casinocourse";

            Dictionary[Stage.BonusStage1]            = "bonusstage1";
            Dictionary[Stage.BonusStage2]            = "bonusstage2";
            Dictionary[Stage.BonusStage3]            = "bonusstage3";
            Dictionary[Stage.BonusStage4]            = "bonusstage4";
            Dictionary[Stage.BonusStage5]            = "bonusstage5";
            Dictionary[Stage.BonusStage6]            = "bonusstage6";
            Dictionary[Stage.BonusStage7]            = "bonusstage7";

            Dictionary[Stage.SeasideHill2P]          = "seasidehill2p";
            Dictionary[Stage.GrandMetropolis2P]      = "grandmetropolis";
            Dictionary[Stage.BingoHighway2P]         = "bingohighway";

            Dictionary[Stage.CityTopBattle]          = "citytop";
            Dictionary[Stage.CasinoRingBattle]       = "casinoring";
            Dictionary[Stage.TurtleShellBattle]      = "turtleshell";

            Dictionary[Stage.EggTreat]               = "eggtreat";
            Dictionary[Stage.PinballMatch]           = "pinballmatch";
            Dictionary[Stage.HotElevator]            = "hotelevator";

            Dictionary[Stage.RoadRock]               = "roadrock";
            Dictionary[Stage.MadExpress]             = "madexpress";
            Dictionary[Stage.TerrorHall]             = "terrorhall";

            Dictionary[Stage.RailCanyonExpert]       = "railcanyon";
            Dictionary[Stage.FrogForestExpert]       = "frogforest";
            Dictionary[Stage.EggFleetExpert]         = "eggfleet";

            Dictionary[Stage.EmeraldChallenge1]      = "bonusstage1";
            Dictionary[Stage.EmeraldChallenge2]      = "bonusstage2";
            Dictionary[Stage.EmeraldChallenge3]      = "bonusstage3";
            Dictionary[Stage.EmeraldChallenge4]      = "bonusstage4";
            Dictionary[Stage.EmeraldChallenge5]      = "bonusstage5";
            Dictionary[Stage.EmeraldChallenge6]      = "bonusstage6";
            Dictionary[Stage.EmeraldChallenge7]      = "bonusstage7";

            Dictionary[Stage.SpecialStageMultiplayer1] = "bonusstage1";
            Dictionary[Stage.SpecialStageMultiplayer2] = "bonusstage4";
            Dictionary[Stage.SpecialStageMultiplayer3] = "bonusstage7";
        }
    }
}
