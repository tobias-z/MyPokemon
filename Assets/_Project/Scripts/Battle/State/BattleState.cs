using System.Collections;

namespace Battle.State
{
    public abstract class BattleState
    {
        protected readonly BattleSystem BattleSystem;

        protected BattleState(BattleSystem battleSystem)
        {
            BattleSystem = battleSystem;
        }

        public abstract IEnumerator Start();

        public virtual IEnumerator Update()
        {
            yield break;
        }
        
        public virtual IEnumerator Cleanup()
        {
            yield break;
        }
    }
}