using System.Collections;

namespace Menus.StartMenu
{
    public abstract class MenuState
    {
        protected readonly MenuSystem MenuSystem;
        
        protected MenuState(MenuSystem menuSystem)
        {
            MenuSystem = menuSystem;
        }

        public virtual IEnumerator CreateMenu()
        {
            yield break;
        }
        
        public virtual IEnumerator DeleteMenu()
        {
            yield break;
        }
    }
}