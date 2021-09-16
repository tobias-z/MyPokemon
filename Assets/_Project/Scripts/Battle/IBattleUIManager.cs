using _Project.Scripts.Core;

namespace _Project.Scripts.Battle
{
    public interface IBattleUIManager
    {
        public string CurrentText { get; }
        IToggle AttackUI { get; }
        IToggle TextDots { get; }
        void SetBattleText(string message);
    }
}