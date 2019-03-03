using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using System.Collections.Generic;

namespace DanielEverland.ScriptableObjectArchitecture.Utility
{
    public interface IStackTraceObject
    {
        List<StackTraceEntry> StackTraces { get; }

        void AddStackTrace();
        void AddStackTrace(object value);
    }
}