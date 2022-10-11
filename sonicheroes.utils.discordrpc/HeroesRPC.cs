using DiscordRPC;
using Heroes.SDK.API;
using Heroes.SDK.Definitions.Enums;
using Heroes.SDK.Definitions.Enums.Custom;
using Heroes.SDK.Definitions.Structures.State;
using SonicHeroes.Utils.DiscordRPC.Heroes;
using SonicHeroes.Utils.DiscordRPC.Heroes.Utilities;

namespace SonicHeroes.Utils.DiscordRPC;

public class HeroesRPC : IDisposable
{
    private readonly DiscordRpcClient _discordRpc;
    private readonly CutsceneTracker _cutsceneTracker;
    private readonly Timer _timer;
    private bool _enableRpc = true;

    private readonly VictoryCounter _victoryCounter;

    /* Setup/Teardown */

    public HeroesRPC()
    {
        _cutsceneTracker = new CutsceneTracker();
        _victoryCounter  = new VictoryCounter();

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
    public void Suspend() => _enableRpc = false;
    public void Resume()  => _enableRpc = true;

    /* Implementation */
    private unsafe void OnTick(object? state)
    {
        if (!_enableRpc) 
            return;
        
        var richPresence = new RichPresence();
        richPresence.Details = GetCurrentDetails();
        richPresence.State = GetGameState();
        richPresence.Assets = new Assets();

        // Contains the start of current action.
        var timeStamps = new Timestamps();

        // Set timestamp.
        if ((!State.IsInMainMenu()) && (!State.IsPaused()) && (!State.IsWatchingIngameEvent()))
        {
            // Do not set timestamp if paused.
            DateTime levelStartTime = DateTime.UtcNow.Subtract(World.Time.ToTimeSpan());
            timeStamps.Start = levelStartTime;
            richPresence.Timestamps = timeStamps;
        }

        // Get Image
        if (!State.IsInMainMenu() && ImageNameDictionary.Dictionary.TryGetValue(State.CurrentStage, out string? stageAssetName))
            richPresence.Assets.LargeImageKey = stageAssetName;

        // Send to Discord
        _discordRpc.SetPresence(richPresence);
    }

    /// <summary>
    /// Gets text set directly under game name on Discord.
    /// </summary>
    private string GetCurrentDetails()
    {
        string currentDetails;

        if (_cutsceneTracker.IsPlayingFmv)
            currentDetails = "Watching FMV";
        else if (State.IsWatchingIngameEvent())
            currentDetails = $"Watching Cutscene in {State.GetStageName()}";
        else if (State.IsInMainMenu())
            currentDetails = $"Navigating the Menus";
        else if (State.IsMultiplayerMode())
            currentDetails = $"Versus Mode: {State.GetStageName()}";
        else
            currentDetails = $"Playing in {State.GetStageName()}";

        return currentDetails;
    }

    /// <summary>
    /// Retrieves the current state of the game.
    /// </summary>
    private unsafe string GetGameState()
    {
        string currentGameState = "";

        // Normal Game (Playing)
        if ((!State.IsWatchingIngameEvent()) && (State.GameState == GameState.InGame))
        {
            if (State.ModeSwitch.TryDereference(out ModeSwitch* modeSwitch))
            {
                MissionMode missionMode = modeSwitch->Mission;

                switch (missionMode)
                {
                    case MissionMode.HardMode when Player.Teams[0] != Team.Sonic:
                        currentGameState = $"Hard Mode, Team {Player.GetTeamName(Players.One)}";
                        break;

                    case MissionMode.HardMode:
                        currentGameState = $"Hard Mode";
                        break;

                    case MissionMode.Alternate:
                        currentGameState = $"Team {Player.GetTeamName(Players.One)}, Mission II";
                        break;

                    default:
                        currentGameState = $"Team {Player.GetTeamName(Players.One)}";
                        break;
                }
            }
        }

        // Two player mode.
        if (State.IsMultiplayerMode() && (!State.IsInMainMenu()))
        {
            int total1PVictories = _victoryCounter.GetTotalVictoryCount(Players.One);
            int total2PVictories = _victoryCounter.GetTotalVictoryCount(Players.Two);

            int current1PVictories = _victoryCounter.GetVictoryCount(Players.One);
            int current2PVictories = _victoryCounter.GetVictoryCount(Players.Two);

            string teamName1P = Player.GetTeamName(Players.One);
            string teamName2P = Player.GetTeamName(Players.Two);

            currentGameState = $"Total: {total1PVictories}-{total2PVictories} | {teamName1P} vs {teamName2P} | Set: {current1PVictories}-{current2PVictories}";
        }

        // Gameplay Paused
        if (State.IsPaused())
            currentGameState = "Paused";

        return currentGameState;
    }
}