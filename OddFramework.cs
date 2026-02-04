using MelonLoader;
using MelonLoader.Utils;
using System.Collections.Generic;
using System.IO;

[assembly: MelonInfo(typeof(OddFramework.OddFrameworkMod), "OddFramework", "1.0.0", "LoulouNoLegend")]

namespace OddFramework
{
    public class OddFrameworkMod : MelonMod
    {
        bool testConfigFile = false;

        private readonly List<InFeature> _features = new()
        {
            new Features.CheaterModeEnforcer(),
            new Features.OverlayFeature(),
        };

        public override void OnInitializeMelon()
        {
            Log.Info("Loaded.");
            foreach (var f in _features) f.Init();

            Config.Verify();
        }

        // Transfer code to InFeature to stop having too much in the fricking files and separated for features
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            foreach (var f in _features) f.OnSceneLoaded(buildIndex, sceneName);
        }

        public override void OnUpdate()
        {
            foreach (var f in _features) f.Tick();
        }

        public override void OnGUI()
        {
            foreach (var f in _features) f.Draw();
        }
    }
}
