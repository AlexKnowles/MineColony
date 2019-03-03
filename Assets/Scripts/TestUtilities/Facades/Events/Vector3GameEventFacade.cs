using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using DanielEverland.ScriptableObjectArchitecture.Events.Listeners;
using UnityEngine;

namespace MineColony.TestUtilities.Facades.Events
{
    public class Vector3GameEventFacade : IGameEventListener<Vector3>
    {
        public readonly Vector3GameEvent GameEvent;
        public bool EventWasRaised { get; private set; }
        public Vector3 EventRaisedValue { get; private set; }

        public Vector3GameEventFacade()
        {
            Reset();

            GameEvent = ScriptableObject.CreateInstance<Vector3GameEvent>();
            GameEvent.AddListener(this);
        }

        public void OnEventRaised(Vector3 value)
        {
            EventWasRaised = true;
            EventRaisedValue = value;
        }

        public void Reset()
        {
            EventWasRaised = false;
            EventRaisedValue = Vector3.zero;
        }
    }
}