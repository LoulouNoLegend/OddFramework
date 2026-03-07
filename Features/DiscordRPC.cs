using Il2Cpp;
using OddFramework.Core;
using UnityEngine.SceneManagement;
using System.Reflection;

namespace OddFramework.Features
{
    internal class DiscordRPC : InFeature
    {
        public Discord.Discord discord;
        private Discord.ActivityManager.UpdateActivityHandler _activityHandler;

        public void Init() {
            Log.Info("Discord Initialisation...");

            long clientID = 1469491553130254498L;

            try
            {
                discord = new Discord.Discord(clientID, (UInt64)Discord.CreateFlags.Default);

                var activity = new Discord.Activity
                {
                    State = "State",
                    Details = "Details",
                    Assets = {
                        LargeImage = "largeImageKey",
                        LargeText = "largeImageText",
                        SmallImage = "smallImageKey",
                        SmallText = "smallImageText",
                    }
                };

                _activityHandler = (result) => {
                    Log.Info($"Discord Activity update: {result}");
                };

                discord.GetActivityManager().UpdateActivity(activity, _activityHandler);

                Log.Info("Discord Initialized.");
                OddFrameworkMod.Instance.discordRpcState = "Connected";
            }   
            catch (Exception e)
            {
                Log.Error($"Discord failed to start: {e.Message}");
                OddFrameworkMod.Instance.discordRpcState = "Disconnected (Error)";
            }
        }

        public void Draw() { }

        public void OnSceneLoaded(int buildIndex, string sceneName) {
            UpdateActivity();
        }

        public void Tick() {
            if (discord != null)
            {
                discord.RunCallbacks();
            }
        }

        public void Shutdown() {
            discord?.Dispose();
            _activityHandler = null;
        }

        public void CustomActivity(string State, string Details, string LargeImageKey, string LargeImageText, string SmallImageKey, string SmallImageText) {
            var activity = new Discord.Activity
            {
                State = State,
                Details = Details,
                Assets = {
                        LargeImage = LargeImageKey,
                        LargeText = LargeImageText,
                        SmallImage = SmallImageKey,
                        SmallText = SmallImageText,
                    }
            };

            _activityHandler = (result) => {
                Log.Info($"Discord Activity update: {result}");
            };

            discord.GetActivityManager().UpdateActivity(activity, _activityHandler);
        }

        public void UpdateActivity()
        {
            var activity = new Discord.Activity
            {
                State = String.Concat("OddFramework v", OddFrameworkMod.Instance.modVersion),
                Details = CheckSceneDictionary(),
                Assets = {
                        LargeImage = "largeImage",
                        LargeText = "largText",
                        SmallImage = "smallImage",
                        SmallText = "smallText",
                    }
            };

            _activityHandler = (result) => {
                Log.Info($"Discord Activity update: {result}");
            };

            discord.GetActivityManager().UpdateActivity(activity, _activityHandler);
        }

        public string CheckSceneDictionary()
        {
            string SceneName = SceneManager.GetActiveScene().name;

            //var waveSpawnerObj = UnityEngine.Object.FindObjectOfType<waveSpawner>();

            if (SceneName == "Odd_main_hub") SceneName = "Main Hub";
            else if (SceneName == "Odd_main_testRoom 1") SceneName = "Test Room";
            else if (SceneName == "Odd_main_lorePlayground") SceneName = "Dev Test Room";
            else if (SceneName.StartsWith("Odd_main_tutorial")) SceneName = "Tutorial";
            else {
                SceneName = SceneManager.GetActiveScene().name;

                if (SceneName.StartsWith("Odd_main_")) SceneName = SceneName.Substring(9);
            }

            /*if (waveSpawnerObj != null)
            {
                FieldInfo field = typeof(waveSpawner).GetField("levelTitle", BindingFlags.NonPublic | BindingFlags.Instance);

                if (field != null)
                {
                    Log.Info("Returning WaveSpawner taken Field.");
                    return field.GetValue(waveSpawnerObj)?.ToString() ?? SceneName;
                }
            }*/

            return SceneName;
        }
    }
}
