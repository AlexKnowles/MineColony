using DanielEverland.ScriptableObjectArchitecture.Variables;
using UnityEngine;

namespace DanielEverland.ScriptableObjectArchitecture.References
{
    [System.Serializable]
    public class ObjectReference : BaseReference<Object, ObjectVariable>
    {
        public ObjectReference() : base() { }
        public ObjectReference(Object value) : base(value) { }
    }
}