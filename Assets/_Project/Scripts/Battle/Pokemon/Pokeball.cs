using System;
using Core;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.Pokemon
{
    public class Pokeball : MonoBehaviour
    {
        private Image _image;

        private void Init()
        {
            _image = GetComponent<Image>();
        }

        public void Enable()
        {
            ChangeImageAlpha(255);
        }

        public void Disable()
        {
            ChangeImageAlpha(50);
        }

        private void ChangeImageAlpha(float alpha)
        {
            // For some reason awake was called later then Enable was called
            if (_image == null)
                Init();
            
            if (Math.Abs(alpha - 50) < 10)
            {
                _image.color = Color.black;
            }
            
            _image.SetTransparency(alpha);
        }
    }
}