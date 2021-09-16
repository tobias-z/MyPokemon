using _Project.Scripts.Core;

namespace _Project.Scripts.Battle
{
    public interface IBattleUIManager
    {
        IToggle AttackUI { get; }
        void SetBattleText(string message);
    }
}