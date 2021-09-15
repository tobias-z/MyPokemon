using UnityEngine;

namespace _Project.Scripts.Menus.StartMenu
{
    public class MenuSystem : MenuStateMachine
    {
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject optionsMenu;

        public GameObject MainMenu => mainMenu;

        public GameObject OptionsMenu => optionsMenu;

        private void Start()
        {
            SetState(new MainMenu(this));
        }

    }
}