using Heroes.SDK.API;
using Heroes.SDK.Classes.NativeClasses;
using Heroes.SDK.Definitions.Enums.Custom;
using Heroes.SDK.Definitions.Structures.State;
using Reloaded.Hooks.Definitions;

namespace SonicHeroes.Utils.DiscordRPC.Heroes
{
    public unsafe class VictoryCounter
    {
        // Members
        private VictoryTracker  _lastVictoryCount;
        private VictoryTracker  _totalVictories;

        private IHook<TObjTeam.Native_Exec> _tObjTeamExecHook;

        // Constructor
        public VictoryCounter()
        {
            _tObjTeamExecHook = TObjTeam.Fun_Exec.Hook(CheckScoreIncrementHookFunction).Activate();
        }

        // Methods

        /// <summary>
        /// Returns the number of victories in the current set.
        /// </summary>
        public int GetVictoryCount(Players player) => State.VictoryTracker.GetNumberOfVictories(player);

        /// <summary>
        /// Returns the total number of victories since the game started.
        /// </summary>
        public int GetTotalVictoryCount(Players player) => _totalVictories.GetNumberOfVictories(player);

        /// <summary>
        /// Executes original function and checks for possible increment of player score.
        /// </summary>
        private void* CheckScoreIncrementHookFunction(ref TObjTeam thisPointer)
        {
            void* result = _tObjTeamExecHook.OriginalFunction(ref thisPointer);

            // Custom Code
            var tracker = State.VictoryTracker;

            if (tracker.PlayerOne > _lastVictoryCount.PlayerOne)         _totalVictories.PlayerOne++;
            if (tracker.PlayerTwo > _lastVictoryCount.PlayerTwo)         _totalVictories.PlayerTwo++;
            if (tracker.PlayerThree > _lastVictoryCount.PlayerThree)     _totalVictories.PlayerThree++;
            if (tracker.PlayerFour > _lastVictoryCount.PlayerFour)       _totalVictories.PlayerFour++;

            _lastVictoryCount = tracker;

            // End of Custom Code
            return result;
        }
    }
}
