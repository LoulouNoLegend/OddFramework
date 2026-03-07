using OddFramework.Core;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace OddFramework.Features
{
    public class OverlayFeature : InFeature
    {
        private bool _show = true;
        private GUIStyle _titleStyle, _lineStyle, _toggleLineStyle;
        private float _totalPanelHeight = 0, _panelSavedHeight = 0;

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

            if (_titleStyle == null)
            {
                _titleStyle = new GUIStyle();
                _titleStyle.normal.textColor = Color.hotPink;
                _titleStyle.fontSize = 24;
            }

            if (_lineStyle == null)
            {
                _lineStyle = new GUIStyle();
                _lineStyle.normal.textColor = Color.white;
                _lineStyle.fontSize = 16;
            }

            if (_toggleLineStyle == null)
            {
                _toggleLineStyle = new GUIStyle();
                _toggleLineStyle.normal.textColor = Color.paleVioletRed;
                _toggleLineStyle.fontSize = 14;
            }

            UI.Panel(new Rect(10, 10, 420, _panelSavedHeight), () => {
                _totalPanelHeight = 0;

                GUI.Label(new Rect(10, 10, 500, 30), "OddFramework " + OddFrameworkMod.Instance.modVersion, _titleStyle);
                _totalPanelHeight += 32;
                GUI.Label(new Rect(10, 42, 400, 20), "DiscordRPC: " + OddFrameworkMod.Instance.discordRpcState, _lineStyle);
                _totalPanelHeight += 22;
                GUI.Label(new Rect(10, 64, 400, 20), "Scene: " + SceneManager.GetActiveScene().name, _lineStyle);
                _totalPanelHeight += 22;
                GUI.Label(new Rect(10, 88, 400, 20), "F8: toggle this menu", _toggleLineStyle);
                _totalPanelHeight += 30;

                _panelSavedHeight = _totalPanelHeight + 20;
            });
        }
    }
}
