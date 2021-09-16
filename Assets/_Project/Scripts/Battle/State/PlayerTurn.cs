using System;
using System.Collections;
using _Project.Scripts.Core;
using UnityEngine;

namespace _Project.Scripts.Battle.State
{
    public class PlayerTurn : BattleState
    {
        private string _dot;
        private StopRepeat _stopRepeat;

        public PlayerTurn(BattleSystem battleSystem) : base(battleSystem)
        {
            _dot = ".";
        }

        public override IEnumerator Start()
        {
            BattleSystem.UI.AttackUI.Enable();
            BattleSystem.UI.SetBattleText($"What should 'POKEMON_NAME' do?{_dot}");

            _stopRepeat = BattleSystem.EventManager.RepeatEvent((sender, args) => AppendDots(), 0, 1);
            yield break;
        }

        public override IEnumerator Cleanup()
        {
            _stopRepeat?.Invoke();
            yield break;
        }

        private void AppendDots()
        {
            _dot += ".";
            if (_dot.Equals("....")) _dot = ".";
            BattleSystem.UI.SetBattleText($"What should 'POKEMON_NAME' do?{_dot}");
        }

    }
}