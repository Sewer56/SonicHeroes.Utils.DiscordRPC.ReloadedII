using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using DiscordRPC;
using Reloaded.Hooks.ReloadedII.Interfaces;
using SonicHeroes.Utils.DiscordRPC.Heroes.Definitions.Enums;
using SonicHeroes.Utils.DiscordRPC.Heroes.Utilities;

namespace SonicHeroes.Utils.DiscordRPC
{
    public class HeroesRPC : IDisposable
    {
        private DiscordRpcClient _discordRpc;
        private Heroes.Heroes _heroes;
        private System.Threading.Timer _timer;
        private bool _enableRpc = true;
        
        /* Setup/Teardown */

        public HeroesRPC(IReloadedHooks hooks)
        {
            _heroes = new Heroes.Heroes(hooks);
            _discordRpc = new DiscordRpcClient("494266376899395605"); // Not like you could get this from decompiling anyway. Obfuscation? That sucks.
            _discordRpc.Initialize();
            _timer = new Timer(OnTick, null, 0, 5000);
        }

        public void Dispose()
        {
            _discordRpc?.Dispose();
            _timer?.Dispose();
        }

        /* Mod Loader API Helpers */
        public void Suspend()
        {
            _enableRpc = false;
        }

        public void Resume()
        {
            _enableRpc = true;
        }

        /* Implementation */
        private unsafe void OnTick(object state)
        {
            if (_enableRpc)
            {
                var richPresence = new RichPresence();
                richPresence.Details = GetCurrentDetails();
                richPresence.State = GetGameState();
                richPresence.Assets = new Assets();

                // Contains the start of current action.
                Timestamps timeStamps = new Timestamps();

                // Set timestamp.
                if ((!_heroes.IsInMainMenu()) && (!_heroes.IsPaused()) && (!_heroes.IsWatchingIngameEvent()))
                {
                    // Do not set timestamp if paused.
                    DateTime levelStartTime = DateTime.UtcNow.Subtract(new TimeSpan(0, 0, (int)(*_heroes.CurrentStageTime).GetTotalSeconds()));
                    timeStamps.Start = levelStartTime;
                    richPresence.Timestamps = timeStamps;
                }

                // Get Image
                if (!_heroes.IsInMainMenu())
                {
                    if (ImageNameDictionary.Dictionary.TryGetValue(*_heroes.StageID, out string stageAssetName))
                    {
                        richPresence.Assets.LargeImageKey = stageAssetName;
                    }
                }

                // Send to Discord
                _discordRpc.SetPresence(richPresence);
            }
        }

        /// <summary>
        /// Gets text set directly under game name on Discord.
        /// </summary>
        private string GetCurrentDetails()
        {
            string currentDetails;

            if (_heroes.IsPlayingFmv)
                currentDetails = "Watching FMV";

            else if (_heroes.IsWatchingIngameEvent())
                currentDetails = $"Watching Cutscene in {_heroes.GetStageName()}";

            else if (_heroes.IsInMainMenu())
                currentDetails = $"Navigating the Menus";

            else if (_heroes.IsTwoPlayer())
                currentDetails = $"Versus Mode: {_heroes.GetStageName()}";

            else
                currentDetails = $"Playing in {_heroes.GetStageName()}";

            return currentDetails;
        }

        /// <summary>
        /// Retrieves the current state of the game.
        /// </summary>
        private unsafe string GetGameState()
        {
            string currentGameState = "";

            // Normal Game (Playing)
            if ((!_heroes.IsWatchingIngameEvent()) && (*_heroes.GameState == GameState.InGame))
            {
                MissionMode missionMode = (**_heroes.GameControlStructPointer).MissionMode;

                switch (missionMode)
                {
                    case MissionMode.HardMode when *_heroes.TeamOne != Team.Sonic:
                        currentGameState = $"Hard Mode, Team {_heroes.GetTeamName(1)}";
                        break;

                    case MissionMode.HardMode:
                        currentGameState = $"Hard Mode";
                        break;

                    case MissionMode.Alternate:
                        currentGameState = $"Team {_heroes.GetTeamName(1)}, Mission II";
                        break;

                    default:
                        currentGameState = $"Team {_heroes.GetTeamName(1)}";
                        break;
                }
            }

            // Two player mode.
            if (_heroes.IsTwoPlayer() && (!_heroes.IsInMainMenu()))
            {
                int total1PVictories = _heroes.VictoryTracker.GetTotalVictoryCount(1);
                int total2PVictories = _heroes.VictoryTracker.GetTotalVictoryCount(2);

                int current1PVictories = _heroes.VictoryTracker.GetVictoryCount(1);
                int current2PVictories = _heroes.VictoryTracker.GetVictoryCount(2);

                string teamName1P = _heroes.GetTeamName(1);
                string teamName2P = _heroes.GetTeamName(2);

                currentGameState = $"Total: {total1PVictories}-{total2PVictories} | {teamName1P} vs {teamName2P} | Set: {current1PVictories}-{current2PVictories}";
            }


            // Gameplay Paused
            if (_heroes.IsPaused())
                currentGameState = "Paused";

            return currentGameState;
        }
    }
}
