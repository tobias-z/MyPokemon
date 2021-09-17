using System;

namespace _Project.Scripts.Core
{
    public delegate void StopRepeat();
    
    public interface IRepeater
    {
        StopRepeat Repeat(EventHandler handler, double jumpTime);
    }
}