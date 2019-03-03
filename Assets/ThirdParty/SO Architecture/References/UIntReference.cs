using DanielEverland.ScriptableObjectArchitecture.Variables;

namespace DanielEverland.ScriptableObjectArchitecture.References
{
    [System.Serializable]
    public sealed class UIntReference : BaseReference<uint, UIntVariable>
    {
        public UIntReference() : base() { }
        public UIntReference(uint value) : base(value) { }
    }
}