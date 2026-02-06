namespace OddFramework.Core
{
    public interface InFeature
    {
        void Init();
        void OnSceneLoaded(int buildIndex, string sceneName);
        void Tick();
        void Draw();
    }
}
