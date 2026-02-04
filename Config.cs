using MelonLoader.Utils;

namespace OddFramework
{
    internal class Config
    {
        public static void Load() { }
        public static void Save() { }
        public static void Verify() {
            bool saveFileExists = false;

            Log.Info("Verifying config file.");
            saveFileExists = File.Exists(Path.Combine(MelonEnvironment.UserDataDirectory, "OddFramework.cfg"));

            if (!saveFileExists)
            {
                Log.Warn("Config file not found. One was created inside " + MelonEnvironment.UserDataDirectory + ".");
                File.Create(Path.Combine(MelonEnvironment.UserDataDirectory, "OddFramework.cfg"));
            }
        }

        public Config(string name) { 
            

        }
    }
}
