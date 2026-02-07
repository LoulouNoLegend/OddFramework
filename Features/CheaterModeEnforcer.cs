using OddFramework.Core;

// Can prevent cheating in leaderboards if there's run modifiers mods to cheat

namespace OddFramework.Features
{
    public class CheaterModeEnforcer : InFeature
    {
        private bool _applied;
        private readonly Every _retry = new(1.0f);

        public void Init() { }
        public void Draw() { }

        public void OnSceneLoaded(int buildIndex, string sceneName)
        {
            _applied = false;
        }

        public void Tick()
        {
            if (_applied) return;
            if (!_retry.Ready()) return;

            var energy = UnityEngine.Object.FindObjectOfType<Il2Cpp.playerEnergy>();
            if (energy == null) return;

            if (!energy.hasCheated) {
                energy.hasCheated = true;
                Log.Warn("Mods detected -> hasCheated forced TRUE (leaderboards disabled).");
            }

            _applied = true;
        }
    }
}
