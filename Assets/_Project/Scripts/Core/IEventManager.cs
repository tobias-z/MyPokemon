using System;

namespace _Project.Scripts.Core
{
    public delegate void StopRepeat();
    
    public interface IEventManager
    {
        void AddEvent(EventHandler handler);

        StopRepeat RepeatEvent(EventHandler handler, double jumpTime);
    }
}