using DanielEverland.ScriptableObjectArchitecture.Variables;

namespace DanielEverland.ScriptableObjectArchitecture.References
{
    [System.Serializable]
    public sealed class ShortReference : BaseReference<short, ShortVariable>
    {
        public ShortReference() : base() { }
        public ShortReference(short value) : base(value) { }
    }
}