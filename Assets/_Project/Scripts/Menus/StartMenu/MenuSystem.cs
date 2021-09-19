using UnityEngine;

namespace Menus.StartMenu
{
    public class MenuSystem : MenuStateMachine
    {
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject optionsMenu;
        [SerializeField] private GameObject characterMenu;
        
        [SerializeField] private GameObject battleScreen;

        public GameObject MainMenu => mainMenu;
        public GameObject OptionsMenu => optionsMenu;
        public GameObject CharacterMenu => characterMenu;
        public GameObject BattleScreen => battleScreen;
        
        private void Start()
        {
            SetState(new MainMenu(this));
        }

    }
}