using System.Collections;
using Battle.State;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.Buttons
{
    public class FightButtonManager : MonoBehaviour
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
            battleSystem.Player.Action.Run();
        }

        private IEnumerator OnFightClick()
        {
            battleSystem.UI.AttackUI.Disable();
            battleSystem.UI.SetBattleText($"{battleSystem.Player.ActivePokemon.Name} uses 'ABILITY'");
            yield return new WaitForSeconds(2);
            battleSystem.Player.Action.Attack(battleSystem.Enemy);
            battleSystem.SetState(new EnemyTurn(battleSystem));
        }
    }
}