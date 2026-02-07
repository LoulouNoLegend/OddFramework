using OddFramework.Core;

namespace OddFramework.Features
{
    internal class DiscordRPC : InFeature
    {
        private Discord.Discord discord;
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
                OddFrameworkMod.Instance.discordRpcState = "Working";
            }   
            catch (Exception e)
            {
                Log.Error($"Discord failed to start: {e.Message}");
                OddFrameworkMod.Instance.discordRpcState = "Error";
            }
        }

        public void Draw() { }

        public void OnSceneLoaded(int buildIndex, string sceneName) {
            
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
    }
}
