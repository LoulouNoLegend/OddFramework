using MelonLoader;

namespace OddFramework.Core
{
    public static class Log
    {
        public static void Info(string msg) => MelonLogger.Msg($"[OddFramework] {msg}");
        public static void Warn(string msg) => MelonLogger.Warning($"[OddFramework] {msg}");
        public static void Error(string msg) => MelonLogger.Error($"[OddFramework] {msg}");
    }
}
