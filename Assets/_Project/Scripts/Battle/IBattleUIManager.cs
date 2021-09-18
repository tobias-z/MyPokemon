using Core;
using UnityEngine.UI;

namespace Battle
{
    public interface IBattleUIManager
    {
        public string CurrentText { get; }
        IToggle AttackUI { get; }
        IToggle TextDots { get; }
        void SetBattleText(string message);
    }
}