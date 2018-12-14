using DanielEverland.ScriptableObjectArchitecture.Utility;
using UnityEngine;

namespace DanielEverland.ScriptableObjectArchitecture.Collections
{
    [CreateAssetMenu(
    fileName = "ULongCollection.asset",
    menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_COLLECTION + "ulong",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 17)]
    public class ULongCollection : Collection<ulong>
    {
    }
}