using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using UnityEngine;
using UnityEngine.Events;

namespace DanielEverland.ScriptableObjectArchitecture.Events.Listeners
{
    [ExecuteInEditMode]
    public sealed class GameEventListener : BaseGameEventListener<GameEventBase, UnityEvent>
    {
    }
}