using System.Collections;

namespace _Project.Scripts.Battle.State
{
    public abstract class BattleState
    {
        protected readonly BattleSystem BattleSystem;

        protected BattleState(BattleSystem battleSystem)
        {
            BattleSystem = battleSystem;
        }

        public abstract IEnumerator Start();

        public virtual IEnumerator UpdateState()
        {
            yield break;
        }
    }
}