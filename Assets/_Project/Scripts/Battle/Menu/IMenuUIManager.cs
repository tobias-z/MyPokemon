using Battle.Menu.UI;
using Core;

namespace Battle.Menu
{
    public interface IMenuUIManager
    {
        public string CurrentText { get; }
        IToggle AttackUI { get; }
        IToggle TextDots { get; }
        IMessageQueue MessageQueue { get; }
        void SetBattleText(string message);
    }
}