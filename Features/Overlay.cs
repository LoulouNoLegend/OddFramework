using MelonLoader;
using Microsoft.VisualBasic;
using OddFramework.Core;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OddFramework.Features
{
    public class OverlayFeature : InFeature
    {
        private bool _show = true;

        public void Init() { }
        public void OnSceneLoaded(int buildIndex, string sceneName) { }
        public void Tick()
        {
            if (Keyboard.current != null && Keyboard.current.f8Key.wasPressedThisFrame) {
                _show = !_show;
                Log.Info($"Overlay {(_show ? "ON" : "OFF")}");
            }
        }

        public void Draw()
        {
            if (!_show) return;

            UI.Panel(new Rect(10, 10, 420, 120), () => {
                GUI.Label(new Rect(10, 10, 500, 40), "OddFramework " + OddFrameworkMod.Instance.modVersion);
                GUI.Label(new Rect(10, 52, 400, 20), "DiscordRPC: " + OddFrameworkMod.Instance.discordRpcState);
                GUI.Label(new Rect(10, 74, 400, 20), "F8: toggle this menu");
            });
        }
    }
}
