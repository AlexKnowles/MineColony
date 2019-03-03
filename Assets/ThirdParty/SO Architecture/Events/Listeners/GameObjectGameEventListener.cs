using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using DanielEverland.ScriptableObjectArchitecture.Events.Responses;
using UnityEngine;

namespace DanielEverland.ScriptableObjectArchitecture.Events.Listeners
{
    public sealed class GameObjectGameEventListener : BaseGameEventListener<GameObject, GameObjectGameEvent, GameObjectUnityEvent>
    {
    }
}