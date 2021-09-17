using System;
using System.Timers;
using UnityEngine;

namespace _Project.Scripts.Core
{
    public class EventRepeater : MonoBehaviour, IRepeater
    {
        private event EventHandler Events;

        private void AddEvent(EventHandler handler) => Events += handler;

        public StopRepeat Repeat(EventHandler handler, double jumpTime)
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