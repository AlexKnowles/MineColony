using DanielEverland.ScriptableObjectArchitecture.Variables;

namespace DanielEverland.ScriptableObjectArchitecture.References
{
    [System.Serializable]
    public sealed class BoolReference : BaseReference<bool, BoolVariable>
    {
        public BoolReference() : base() { }
        public BoolReference(bool value) : base(value) { }
    }
}