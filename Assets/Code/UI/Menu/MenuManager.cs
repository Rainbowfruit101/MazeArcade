using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace UI.Menu
{
    //singleton with custom Script Execution Order
    public class MenuManager: MonoBehaviour
    {
        public static MenuManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        [SerializeReference] private MenuBase[] menus;

        public void ShowOnly<TMenu>()
            where TMenu : MenuBase
        {
            foreach (var menu in menus)
            {
                if (menu.GetType() == typeof(TMenu))
                {
                    menu.Show();
                }
                else
                {
                    menu.Hide();
                }
            }
        }
        
        [CanBeNull]
        public TMenu Find<TMenu>()
            where TMenu: MenuBase
        {
            var result = menus.FirstOrDefault(m => m.GetType() == typeof(TMenu));
            if (result == null)
                return null;

            return result as TMenu;
        }
    }
}