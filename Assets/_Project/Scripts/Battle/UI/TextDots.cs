using System;
using Core;

namespace Battle.UI
{
    public class TextDots : IToggle
    {
        private readonly IRepeater _repeater;
        private readonly IBattleUIManager _ui;
        
        private string _startText;
        private string _dot;
        private StopRepeat _stopRepeat;

        public TextDots(IRepeater repeater, IBattleUIManager uiManager)
        {
            _repeater = repeater;
            _ui = uiManager;
            _dot = "";
        }

        public void Enable()
        {
            _startText = _ui.CurrentText;
            _stopRepeat = _repeater.Repeat(AppendDots, 1);
        }

        public void Disable()
        {
            _stopRepeat?.Invoke();
        }
        
        private void AppendDots()
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