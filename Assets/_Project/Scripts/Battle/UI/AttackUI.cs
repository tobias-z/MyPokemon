using Core;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.UI
{
    internal enum Scale
    {
        Up,
        Down
    }

    public class AttackUI : IToggle
    {
        private readonly Image _textImage;
        private readonly Image _attackImage;
        private readonly Vector3 _position;

        public AttackUI(Image textImage, Image attackImage)
        {
            _textImage = textImage;
            _attackImage = attackImage;
            _position = new Vector3(175, 0, 0);
        }

        public void Enable()
        {
            _attackImage.gameObject.SetActive(true);
            _textImage.rectTransform.sizeDelta = GetSizeDelta(Scale.Down);
            _textImage.rectTransform.position -= _position;
        }

        public void Disable()
        {
            _attackImage.gameObject.SetActive(false);
            _textImage.rectTransform.sizeDelta = GetSizeDelta(Scale.Up);
            _textImage.rectTransform.position += _position;
        }
        
        private Vector2 GetSizeDelta(Scale scale)
        {
            var delta = _textImage.rectTransform.sizeDelta;
            var xValue = scale == Scale.Up ? delta.x + 500 : delta.x - 500;
            return new Vector2(xValue, delta.y);
        }
    }
}