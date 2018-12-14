using UnityEngine;
using System.Collections;
using DanielEverland.ScriptableObjectArchitecture.Events.Listeners;

namespace MineColony.Tests.Utilities
{
    public class GameEventListenerFacade : IGameEventListener
    {
        public bool EventWasRaised { get; private set; }

        public GameEventListenerFacade()
        {
            EventWasRaised = false;
        }

        public void OnEventRaised()
        {
            EventWasRaised = true;
        }
    }
}