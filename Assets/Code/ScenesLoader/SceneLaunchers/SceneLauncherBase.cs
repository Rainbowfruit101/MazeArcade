using UnityEngine;

namespace ScenesLoader.SceneLaunchers
{
    public abstract class SceneLauncherBase : MonoBehaviour
    {
        public abstract void Load(SceneLoader sceneLoader);
        public abstract void Unload(SceneLoader sceneLoader);
    }
}