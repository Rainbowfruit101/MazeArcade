using ObjectsStorage.Impls;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu.Impls
{
    public class LeaderboardMenuUIView: MenuBase
    {
        [SerializeField] private Button backButton;

        public void Init(LeaderboardStorageObject.Leaderboard leaderboard)
        {
            backButton.onClick.AddListener(MenuManager.Instance.ShowOnly<MainMenuUIView>);
        }
    }
}