using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Timers;
using _Project.Scripts.Core;
using UnityEngine;

namespace _Project.Scripts.Battle
{
    public class EventManager : MonoBehaviour, IEventManager
    {
        private event EventHandler Events;
        
        public void AddEvent(EventHandler handler)
        {
            Events += handler;
        }

        public StopRepeat RepeatEvent(EventHandler handler, double jumpTime)
        {
            AddEvent(handler);
            var timer = GetTimer(handler, jumpTime);
            timer.Start();
            
            return () =>
            {
                timer.Stop();
                timer.Close();
                timer.Dispose();
            };
        }

        private Timer GetTimer(EventHandler handler, double jumpTime)
        {
            var timer = new Timer(jumpTime * 1000);
            timer.Elapsed += (sender, args) => AddEvent(handler);
            timer.Enabled = true;
            timer.AutoReset = true;
            return timer;
        }

        private void Update()
        {
            Events?.Invoke(this, EventArgs.Empty);
            Events -= Events;
        }
    }
}