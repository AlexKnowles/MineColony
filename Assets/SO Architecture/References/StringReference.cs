using DanielEverland.ScriptableObjectArchitecture.Variables;

namespace DanielEverland.ScriptableObjectArchitecture.References
{
    [System.Serializable]
    public sealed class StringReference : BaseReference<string, StringVariable>
    {
        public StringReference() : base() { }
        public StringReference(string value) : base(value) { }
    }
}