using Heroes.SDK.Classes.NativeClasses;
using Reloaded.Hooks.Definitions;

namespace SonicHeroes.Utils.DiscordRPC.Heroes
{
    public unsafe class CutsceneTracker
    {
        /* Members */
        public bool IsPlayingFmv = false;

        /* Hooks */
        private IHook<MoviePlay.Native_Play> _moviePlayHook;
        private IHook<MoviePlay.Native_End>  _movieEndHook;

        // Constructor
        public CutsceneTracker()
        {
            _moviePlayHook = MoviePlay.Fun_Play.Hook(MoviePlayImpl).Activate();
            _movieEndHook  = MoviePlay.Fun_End.Hook(MovieEndImpl).Activate();
        }

        private int MoviePlayImpl(ref MoviePlay thisPointer)
        {
            IsPlayingFmv = true;
            return _moviePlayHook.OriginalFunction(ref thisPointer);
        }

        private int MovieEndImpl()
        {
            IsPlayingFmv = false;
            return _movieEndHook.OriginalFunction();
        }
    }
}
