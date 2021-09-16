using _Project.Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Battle.UI
{
    public class AttackUI : IToggle
    {
        private readonly Image _textImage;
        private readonly RectTransform _initialImage;
        private readonly Image _attackImage;

        public AttackUI(Image textImage, Image attackImage)
        {
            _textImage = textImage;
            _initialImage = textImage.rectTransform;
            _attackImage = attackImage;
        }

        public void Enable()
        {
            _attackImage.gameObject.SetActive(true);
            ReduceTextSize();
            MoveImageToTheSide();
        }

        public void Disable()
        {
            _attackImage.gameObject.SetActive(false);
            _textImage.rectTransform.sizeDelta = _initialImage.sizeDelta;
            _textImage.rectTransform.position = _initialImage.position;
        }

        private void ReduceTextSize()
        {
            var sizeDelta = _initialImage.sizeDelta;
            sizeDelta = new Vector2(sizeDelta.x - 500, sizeDelta.y);
            _textImage.rectTransform.sizeDelta = sizeDelta;
        }
        
        private void MoveImageToTheSide()
        {
            _textImage.rectTransform.position -= new Vector3(175, 0, 0);
        }

    }
}