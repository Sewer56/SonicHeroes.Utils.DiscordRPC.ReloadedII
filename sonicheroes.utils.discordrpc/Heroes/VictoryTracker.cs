using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using Reloaded.Hooks.ReloadedII.Interfaces;
using SonicHeroes.Utils.DiscordRPC.Heroes.Definitions;

namespace SonicHeroes.Utils.DiscordRPC.Heroes
{
    public unsafe class VictoryTracker
    {
        // Members
        private VictoryStruct* _currentVictoryCount = (VictoryStruct*)0x009DD6BC;
        private VictoryStruct  _lastVictoryCount = new VictoryStruct();

        private int _playerOneTotalVictories   = 0;
        private int _playerTwoTotalVictories   = 0;
        private int _playerThreeTotalVictories = 0;
        private int _playerFourTotalVictories  = 0;

        private IHook<TObjTeam_Exec> _tObjTeamExecHook;

        // Constructor
        public VictoryTracker(IReloadedHooks hooks)
        {
            _tObjTeamExecHook = hooks.CreateHook<TObjTeam_Exec>(CheckScoreIncrementHookFunction, 0x005B10E0).Activate();
        }

        // Methods

        /// <summary>
        /// Player Range: 1-4 
        /// </summary>
        public int GetVictoryCount(int player)
        {
            // Update total victory numbers.
            switch (player)
            {
                case 1: return _currentVictoryCount[0].PlayerOne;
                case 2: return _currentVictoryCount[0].PlayerTwo;
                case 3: return _currentVictoryCount[0].PlayerThree;
                case 4: return _currentVictoryCount[0].PlayerFour;
                default: return 0;
            }
        }

        /// <summary>
        /// Player Range: 1-4 
        /// </summary>
        public int GetTotalVictoryCount(int player)
        {
            // Update total victory numbers.
            switch (player)
            {
                case 1: return _playerOneTotalVictories;
                case 2: return _playerTwoTotalVictories;
                case 3: return _playerThreeTotalVictories;
                case 4: return _playerFourTotalVictories;
                default: return 0;
            }
        }

        /// <summary>
        /// Executes original function and checks for possible increment of player score.
        /// </summary>
        private char CheckScoreIncrementHookFunction(void* thisPointer)
        {
            char result = _tObjTeamExecHook.OriginalFunction(thisPointer);

            // Custom Code
            VictoryStruct currentVictories = *_currentVictoryCount;

            if (currentVictories.PlayerOne > _lastVictoryCount.PlayerOne)
                _playerOneTotalVictories++;

            if (currentVictories.PlayerTwo > _lastVictoryCount.PlayerTwo)
                _playerTwoTotalVictories++;

            if (currentVictories.PlayerThree > _lastVictoryCount.PlayerThree)
                _playerThreeTotalVictories++;

            if (currentVictories.PlayerFour > _lastVictoryCount.PlayerFour)
                _playerFourTotalVictories++;

            _lastVictoryCount = currentVictories;

            // End of Custom Code

            return result;
        }

        [Function(CallingConventions.MicrosoftThiscall)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate char TObjTeam_Exec(void* thisPointer);
    }
}
