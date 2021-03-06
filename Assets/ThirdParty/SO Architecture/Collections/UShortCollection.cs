using DanielEverland.ScriptableObjectArchitecture.Utility;
using UnityEngine;

namespace DanielEverland.ScriptableObjectArchitecture.Collections
{
    [CreateAssetMenu(
    fileName = "UShortCollection.asset",
    menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_COLLECTION + "ushort",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 18)]
    public class UShortCollection : Collection<ushort>
    {
    }
}