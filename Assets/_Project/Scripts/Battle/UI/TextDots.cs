using System;
using _Project.Scripts.Core;
using UnityEngine;

namespace _Project.Scripts.Battle.UI
{
    public class TextDots : IToggle
    {
        private readonly IEventManager _eventManager;
        private readonly IBattleUIManager _ui;
        
        private string _startText;
        private string _dot;
        private StopRepeat _stopRepeat;

        public TextDots(IEventManager eventManager, IBattleUIManager uiManager)
        {
            _eventManager = eventManager;
            _ui = uiManager;
            _dot = "";
        }

        public void Enable()
        {
            _startText = _ui.CurrentText;
            _stopRepeat = _eventManager.RepeatEvent(AppendDots, 0, 1);
        }

        public void Disable()
        {
            _stopRepeat?.Invoke();
        }
        
        private void AppendDots(object sender, EventArgs e)
        {
            CheckForNewText();
            _dot += ".";
            if (_dot.Equals("...."))
            {
                _dot = "";
                _ui.SetBattleText(_startText);
            }
            _ui.SetBattleText($"{_startText}{_dot}");
        }

        private void CheckForNewText()
        {
            if (_ui.CurrentText.StartsWith($"{_startText[0]}")) return;
            _startText = _ui.CurrentText;
        }
    }
}