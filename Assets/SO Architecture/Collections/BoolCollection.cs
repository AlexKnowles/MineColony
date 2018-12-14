using DanielEverland.ScriptableObjectArchitecture.Utility;
using UnityEngine;

namespace DanielEverland.ScriptableObjectArchitecture.Collections
{
    [CreateAssetMenu(
    fileName = "BoolCollection.asset",
    menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "bool",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 5)]
    public class BoolCollection : Collection<bool>
    {
    }
}