using UnityEngine;

namespace Menus.StartMenu
{
    public abstract class MenuStateMachine : MonoBehaviour
    {
        protected MenuState MenuState;

        public void SetState(MenuState menuState)
        {
            if (MenuState != null)
            {
                StartCoroutine(MenuState.DeleteMenu());
            }

            MenuState = menuState;
            StartCoroutine(menuState.CreateMenu());
        }
    }
}