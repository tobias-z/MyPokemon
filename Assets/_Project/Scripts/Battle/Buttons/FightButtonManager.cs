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
            // TODO: Change this
            var ability = battleSystem.Player.ActivePokemon.Abilities[Random.Range(0, 4)];
            
            battleSystem.UI.SetBattleText($"{battleSystem.Player.ActivePokemon.Name} uses {ability.Name}");
            yield return new WaitForSeconds(2);
            
            battleSystem.Player.Action.Attack(battleSystem.Enemy, ability);
            battleSystem.SetState(new EnemyTurn(battleSystem));
        }
    }
}