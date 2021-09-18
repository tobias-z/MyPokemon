using Battle.UI;
using Core;
using UnityEngine.UI;

namespace Battle
{
    public interface IBattleUIManager
    {
        public string CurrentText { get; }
        IToggle AttackUI { get; }
        IToggle TextDots { get; }
        IMessageQueue MessageQueue { get; }
        void SetBattleText(string message);
    }
}