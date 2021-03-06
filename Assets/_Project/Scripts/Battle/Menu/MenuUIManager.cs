using Battle.Menu.UI;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.Menu
{
    public class MenuUIManager : MonoBehaviour, IMenuUIManager
    {
        [SerializeField] private GameObject infoText;
        [SerializeField] private Image attackImage;
        
        public IToggle TextDots { get; private set; }
        public IToggle AttackUI { get; private set; }
        public IMessageQueue MessageQueue { get; private set; }

        public string CurrentText
        {
            get => _textMesh.text;
            private set => _textMesh.text = value;
        }

        private TextMeshProUGUI _textMesh;

        private void Awake()
        {
            _textMesh = infoText.GetComponent<TextMeshProUGUI>();
            CurrentText = _textMesh.text;
            AttackUI = new AttackUI(attackImage);
            TextDots = new TextDots(GetComponent<IRepeater>(), this);
            MessageQueue = GetComponent<IMessageQueue>();
        }
        
        public void SetBattleText(string message) => CurrentText = message;
    }
}