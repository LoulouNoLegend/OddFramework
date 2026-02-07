using Discord;
using OddFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddFramework.Features
{
    internal class DiscordRPC : InFeature
    {
        private Discord.Discord discord;

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

                // 3. You must actually call UpdateActivity to show the status
                discord.GetActivityManager().UpdateActivity(activity, (result) => {
                    Log.Info($"Discord Activity update: {result}");
                });

                Log.Info("Discord Initialized.");
            }
            catch (Exception e)
            {
                Log.Error($"Discord failed to start: {e.Message}");
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
        }
    }
}
