using UnityEngine;

namespace OddFramework.Core
{
    public class Every
    {
        private float _next;
        private readonly float _seconds;

        public Every(float seconds) => _seconds = seconds;

        public bool Ready()
        {
            if (Time.unscaledTime < _next) return false;
            _next = Time.unscaledTime + _seconds;
            return true;
        }
    }
}
