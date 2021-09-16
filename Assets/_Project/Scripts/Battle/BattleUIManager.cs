using _Project.Scripts.Battle.UI;
using _Project.Scripts.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Battle
{
    public class BattleUIManager : MonoBehaviour, IBattleUIManager
    {
        [SerializeField] private Image textImage;
        [SerializeField] private GameObject infoText;
        [SerializeField] private Image attackImage;

        public IToggle AttackUI { get; private set; }

        private TextMeshProUGUI _textMesh;

        private void Awake()
        {
            _textMesh = infoText.GetComponent<TextMeshProUGUI>();
            AttackUI = new AttackUI(textImage, attackImage);
        }
        
        public void SetBattleText(string message) => _textMesh.text = message;
    }
}