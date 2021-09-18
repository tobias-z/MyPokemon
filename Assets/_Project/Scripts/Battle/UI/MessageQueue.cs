using System.Collections.Generic;
using System.Linq;
using Battle.State;
using UnityEngine;

namespace Battle.UI
{
    public interface IMessageQueue
    {
        void StartMessageQueue(IEnumerable<string> messages, BattleState next);
    }

    public class MessageQueue : MonoBehaviour, IMessageQueue
    {
        [SerializeField] private BattleSystem battleSystem;
        
        [Header("Settings")]
        [SerializeField] private KeyCode key = KeyCode.Space;

        private Queue<string> _messages;
        private BattleState _next;

        public void StartMessageQueue(IEnumerable<string> messages, BattleState next)
        {
            _messages = new Queue<string>();
            _next = next;
            foreach (var message in messages)
                _messages.Enqueue(message);
        }

        private void Update()
        {
            if (_messages == null) return;

            if (!_messages.Any())
            {
                _messages = null;
                battleSystem.SetState(_next);
            }

            if (!Input.GetKeyDown(key)) return;
            if (_messages != null)
                battleSystem.UI.SetBattleText(_messages.Dequeue());
        }
    }
}