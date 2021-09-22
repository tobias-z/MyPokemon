using Core;
using UnityEngine.UI;

namespace Battle.Menu.UI
{
    public class AttackUI : IToggle
    {
        private readonly Image _attackImage;

        public AttackUI(Image attackImage)
        {
            _attackImage = attackImage;
        }

        public void Enable()
        {
            _attackImage.gameObject.SetActive(true);
        }

        public void Disable()
        {
            _attackImage.gameObject.SetActive(false);
        }
    }
}