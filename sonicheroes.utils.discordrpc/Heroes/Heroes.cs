using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using Reloaded.Hooks.ReloadedII.Interfaces;
using SonicHeroes.Utils.DiscordRPC.Heroes.Definitions;
using SonicHeroes.Utils.DiscordRPC.Heroes.Definitions.Enums;
using SonicHeroes.Utils.DiscordRPC.Heroes.Utilities;

namespace SonicHeroes.Utils.DiscordRPC.Heroes
{
    public unsafe class Heroes
    {
        /* Pointers */
        public StageID* StageID     = (StageID*)0x008D6710;
        public GameState* GameState = (GameState*)0x008D66F0;

        public Team* TeamOne   = (Team*)0x8D6920;
        public Team* TeamTwo   = (Team*)0x8D6924;
        public Team* TeamThree = (Team*)0x8D6928;
        public Team* TeamFour  = (Team*)0x8D692C;

        public int* NumberOfCameras = (int*)0xA60BE4;
        public SomeGameControlStruct** GameControlStructPointer = (SomeGameControlStruct**)0x00A777E4;

        public Time* CurrentStageTime   = (Time*)0x009DD708;

        private int** _someEventPointer = (int**)0x00A776EC;

        /* Members */
        public bool IsPlayingFmv = false;

        /* Members */
        public StageTagger    StageTagger    { get; set; } = new StageTagger();
        public VictoryTracker VictoryTracker { get; set; }

        private IHook<MoviePlay> _moviePlayHook;
        private IHook<MovieEnd>  _movieEndHook;

        // Constructor
        public Heroes(IReloadedHooks hooks)
        {
            _moviePlayHook = hooks.CreateHook<MoviePlay>(MoviePlayImpl, 0x00643DE0).Activate();
            _movieEndHook  = hooks.CreateHook<MovieEnd>(MovieEndImpl, 0x00643E00).Activate();
            VictoryTracker = new VictoryTracker(hooks);
        }

        private int MoviePlayImpl(int* thisPointer)
        {
            IsPlayingFmv = true;
            return _moviePlayHook.OriginalFunction(thisPointer);
        }

        private int MovieEndImpl()
        {
            IsPlayingFmv = false;
            return _movieEndHook.OriginalFunction();
        }

        /*
            -------
            Methods
            -------
        */

        public bool IsTwoPlayer()
        {
            return *TeamTwo != Team.Null;
        }

        public int GetPlayerCount()
        {
            if (*TeamFour != Team.Null)
                return 4;

            if (*TeamThree != Team.Null)
                return 3;

            if (*TeamTwo != Team.Null)
                return 2;

            return 1;
        }

        public StageTagger.StageTag GetStageTags()
        {
            return StageTagger.CategorizeStage((int)(*StageID));
        }

        public string GetStageName()
        {
            if (StageNameDictionary.Dictionary.TryGetValue(*StageID, out string stageName))
                return stageName;
            else
                return "Custom Stage";
        }

        /// <summary>
        /// PlayerNumber has range 1-4.
        /// </summary>
        public string GetTeamName(int playerNumber)
        {
            Team currentTeam = Team.Null;

            switch (playerNumber)
            {
                case 1:
                    currentTeam = *TeamOne;
                    break;
                case 2:
                    currentTeam = *TeamTwo;
                    break;
                case 3:
                    currentTeam = *TeamThree;
                    break;
                case 4:
                    currentTeam = *TeamFour;
                    break;
            }

            if (TeamNameDictionary.Dictionary.TryGetValue(currentTeam, out string modeState))
                return modeState;
            
            return "Unknown Team";
        }

        public bool IsWatchingIngameEvent()
        {
            return ((CurrentStageTime[0].Seconds == 0) && (CurrentStageTime[0].Minutes == 0) && *_someEventPointer != (void*)0 && !IsInMainMenu());
        }

        public bool IsPaused()
        {
            GameState gameState = *GameState;

            switch (gameState)
            {
                case Definitions.Enums.GameState.InGamePaused:
                case Definitions.Enums.GameState.InGamePausedSettings:
                case Definitions.Enums.GameState.InGamePausedSettingsCamera:
                case Definitions.Enums.GameState.InGamePausedSettingsRebinding:
                    return true;
            }

            return false;
        }

        public bool IsInMainMenu()
        {
            return *GameState == Definitions.Enums.GameState.Menu || *GameState == Definitions.Enums.GameState.Null;
        }

        [Function(CallingConventions.MicrosoftThiscall)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int MoviePlay(int* thisPointer); // 00643DE0

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int MovieEnd(); // 00643E00 
    }
}
