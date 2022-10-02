using UnityEngine;

namespace ScenesLoader
{
    public abstract class OnSceneLoaded: MonoBehaviour
    {
        public abstract void Load(SceneLoader sceneLoader);
        public abstract void Unload(SceneLoader sceneLoader);
    }
}