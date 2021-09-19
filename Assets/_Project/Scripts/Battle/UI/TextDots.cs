using System;
using System.Linq;
using System.Text;
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
            var current = _ui.CurrentText + '.';
            var start = _startText + '.'; 
            var isSameText = current.Split('.')[0].Equals(start.Split('.')[0]);
            if (isSameText) return;
            _startText = _ui.CurrentText;
        }
    }
}