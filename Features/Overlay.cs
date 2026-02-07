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
        private GUIStyle titleStyle;
        private GUIStyle lineStyle;

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

            if (titleStyle == null)
            {
                titleStyle = new GUIStyle();
                titleStyle.normal.textColor = Color.hotPink;
                titleStyle.fontSize = 24;
            }

            if (lineStyle == null)
            {
                lineStyle = new GUIStyle();
                lineStyle.normal.textColor = Color.white;
                lineStyle.fontSize = 16;
            }

            UI.Panel(new Rect(10, 10, 420, 120), () => {
                GUI.Label(new Rect(10, 10, 500, 30), "OddFramework " + OddFrameworkMod.Instance.modVersion, titleStyle);
                GUI.Label(new Rect(10, 42, 400, 20), "DiscordRPC: " + OddFrameworkMod.Instance.discordRpcState, lineStyle);
                GUI.Label(new Rect(10, 64, 400, 20), "F8: toggle this menu", lineStyle);
            });
        }
    }
}
