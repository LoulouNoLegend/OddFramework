using MelonLoader;

namespace OddFramework.Core
{
    public static class Log
    {
        public static void Info(string msg) => MelonLogger.Msg($"{msg}");
        public static void Warn(string msg) => MelonLogger.Warning($"{msg}");
        public static void Error(string msg) => MelonLogger.Error($"{msg}");
    }
}
