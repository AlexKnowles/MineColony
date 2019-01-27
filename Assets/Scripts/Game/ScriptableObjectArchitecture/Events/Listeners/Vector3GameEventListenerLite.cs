using UnityEngine;
using System.Collections;
using DanielEverland.ScriptableObjectArchitecture.Events.Listeners;
using System;

public class Vector3GameEventListenerLite : IGameEventListener<Vector3>
{
    public Action<Vector3> EventsToRaise;  

    public void OnEventRaised(Vector3 value)
    {
        EventsToRaise.Invoke(value);
    }
}
