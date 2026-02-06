using UnityEngine;

namespace OddFramework.Core
{
    public static class UI
    {
        private static GUIStyle _panel;

        public static void Panel(Rect rect, System.Action content)
        {
            if (_panel == null)
            {
                _panel = new GUIStyle(GUI.skin.box);
                _panel.normal.background = Texture2D.whiteTexture;
            }

            // Background
            Color prev = GUI.color;
            GUI.color = new Color(0f, 0f, 0f, 0.7f);
            GUI.Box(rect, GUIContent.none, _panel);
            GUI.color = prev;

            GUI.BeginGroup(rect); // Content area
            GUI.Label(new Rect(10, 10, rect.width - 20, 1), GUIContent.none); // padding

            content();

            GUI.EndGroup();
        }
    }
}
