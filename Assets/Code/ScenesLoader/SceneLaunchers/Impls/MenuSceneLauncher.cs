using ObjectsStorage;
using ObjectsStorage.Impls;
using UI.Menu.Impls;
using UnityEngine;

namespace ScenesLoader.SceneLaunchers.Impls
{
    public class MenuSceneLauncher : SceneLauncherBase
    {
        [SerializeField] private MainMenuUIView mainMenu;
        [SerializeField] private LeaderboardMenuUIView leaderboardMenu;

        
        public override void Load(SceneLoader sceneLoader)
        {
            var progressStorageObject = Storage
                .Load<ProgressStorageObject, ProgressStorageObject.Progress>(new ProgressStorageObject());
            var leaderboardStorageObject = Storage
                .Load<LeaderboardStorageObject, LeaderboardStorageObject.Leaderboard>(new LeaderboardStorageObject());

            mainMenu.Init(progressStorageObject.Data, sceneLoader);
            leaderboardMenu.Init(leaderboardStorageObject.Data);
        }

        public override void Unload(SceneLoader sceneLoader)
        {
            Debug.Log("Menu unloaded");
        }
    }
}