using System;
using System.Timers;
using UnityEngine;

namespace Core
{
    public class EventRepeater : MonoBehaviour, IRepeater
    {
        private event Action Action;

        private void AddEvent(Action action) => Action += action;

        public StopRepeat Repeat(Action action, double jumpTime)
        {
            AddEvent(action);
            var timer = GetTimer(action, jumpTime);
            timer.Start();
            
            return () =>
            {
                timer.Stop();
                timer.Close();
                timer.Dispose();
            };
        }

        private Timer GetTimer(Action action, double jumpTime)
        {
            var timer = new Timer(jumpTime * 1000);
            timer.Elapsed += (sender, args) => AddEvent(action);
            timer.Enabled = true;
            timer.AutoReset = true;
            return timer;
        }

        private void Update()
        {
            Action?.Invoke();
            Action -= Action;
        }
    }
}