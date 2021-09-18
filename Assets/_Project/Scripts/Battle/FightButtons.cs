using System.Collections;
using Battle.State;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class FightButtons : MonoBehaviour
    {
        [SerializeField] private BattleSystem battleSystem;
        [SerializeField] private Button fightButton;
        [SerializeField] private Button runButton;

        private void Awake()
        {
            fightButton.onClick.AddListener(() => StartCoroutine(OnFightClick()));
            runButton.onClick.AddListener(OnRunClick);
        }

        private void OnRunClick()
        {
            battleSystem.Player.Run();
        }

        private IEnumerator OnFightClick()
        {
            battleSystem.UI.AttackUI.Disable();
            battleSystem.UI.SetBattleText($"'NAME' uses 'ABILITY'");
            yield return new WaitForSeconds(2);
            battleSystem.Player.Attack(battleSystem.Enemy);
            battleSystem.SetState(new EnemyTurn(battleSystem));
        }
    }
}