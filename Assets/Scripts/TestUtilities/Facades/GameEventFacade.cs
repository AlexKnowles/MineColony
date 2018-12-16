using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using DanielEverland.ScriptableObjectArchitecture.Events.Listeners;
using UnityEngine;

namespace MineColony.TestUtilities.Facades
{
    public class GameEventFacade : IGameEventListener
    {
        public readonly GameEvent GameEvent;
        public bool EventWasRaised { get; private set; }

        public GameEventFacade()
        {
            EventWasRaised = false;

            GameEvent = ScriptableObject.CreateInstance<GameEvent>();
            GameEvent.AddListener(this);
        }

        public void OnEventRaised()
        {
            EventWasRaised = true;
        }
    }
}