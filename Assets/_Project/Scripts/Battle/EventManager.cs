using System;
using _Project.Scripts.Core;
using UnityEngine;

namespace _Project.Scripts.Battle
{
    internal delegate void Setup();
    
    public class EventManager : MonoBehaviour, IEventManager
    {
        private event EventHandler Events;
        private Setup _setup;
        
        public void AddEvent(EventHandler handler)
        {
            Events += handler;
        }

        public StopRepeat RepeatEvent(EventHandler handler, float startTime, float jumpTime)
        {
            _setup = () => handler.Invoke(this, EventArgs.Empty);
            InvokeRepeating(nameof(InvokeSetup), startTime, jumpTime);
            
            return () =>
            {
                _setup = null;
                CancelInvoke(nameof(InvokeSetup));
            };
        }

        private void InvokeSetup()
        {
            _setup?.Invoke();
        }

        private void Update()
        {
            Events?.Invoke(this, EventArgs.Empty);
        }
    }
}