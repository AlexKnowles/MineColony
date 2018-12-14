using UnityEngine;
using UnityEngine.Events;

namespace DanielEverland.ScriptableObjectArchitecture.Events.Responses
{
    [System.Serializable]
    public class ObjectUnityEvent : UnityEvent<Object>
    {
    }
}