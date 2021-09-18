using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class Pokemon : MonoBehaviour, IPokemon
    {
        [SerializeField] private TextMeshProUGUI health;
        [SerializeField] private Slider slider;
        
        public void Attack(IPokemon pokemon)
        {
            pokemon.TakeDamage(20);
        }

        public void Run()
        {
            Application.Quit();
        }

        public void TakeDamage(float amount)
        {
            slider.value -= amount;
            SetHealthText(slider.value);
        }

        public void Die()
        {
            print("I have died");
            slider.value = 100;
        }

        private void SetHealthText(float amount)
        {
            health.text = $"{amount}/{health.text.Split('/')[1]}";
        }

        private void Update()
        {
            if (slider.value <= 0)
            {
                Die();
            }
        }
    }
}