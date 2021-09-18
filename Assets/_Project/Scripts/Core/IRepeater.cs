using System;

namespace Core
{
    public delegate void StopRepeat();
    
    public interface IRepeater
    {
        StopRepeat Repeat(Action action, double jumpTime);
    }
}