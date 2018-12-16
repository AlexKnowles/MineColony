using DanielEverland.ScriptableObjectArchitecture.Variables;

namespace DanielEverland.ScriptableObjectArchitecture.References
{
    [System.Serializable]
    public sealed class DoubleReference : BaseReference<double, DoubleVariable>
    {
        public DoubleReference() : base() { }
        public DoubleReference(double value) : base(value) { }
    }
}