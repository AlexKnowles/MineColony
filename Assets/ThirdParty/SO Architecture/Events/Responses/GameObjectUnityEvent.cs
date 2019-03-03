using UnityEngine;
using UnityEngine.Events;

namespace DanielEverland.ScriptableObjectArchitecture.Events.Responses
{
    [System.Serializable]
    public sealed class GameObjectUnityEvent : UnityEvent<GameObject>
    {
    }
}