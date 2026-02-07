using Il2Cpp;
using MelonLoader;
using MelonLoader.Utils;
using OddFramework;
using OddFramework.Core;
using System.Collections.Generic;
using System.IO;

using static MelonLoader.Modules.MelonModule;

[assembly: MelonInfo(typeof(OddFramework.OddFrameworkMod), "OddFramework", "0.0.2", "LoulouNoLegend")]

namespace OddFramework
{
    public class OddFrameworkMod : MelonMod
    {
        bool testConfigFile = false;

        public static OddFrameworkMod Instance { get; private set; }
        public string modVersion;

        public string discordRpcState;

        private readonly List<InFeature> _features = new()
        {
            //new Features.CheaterModeEnforcer(),
            new Features.OverlayFeature(),
            new Features.DiscordRPC(),
        };

        public override void OnInitializeMelon()
        {
            Instance = this;
            modVersion = Info.Version;

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
