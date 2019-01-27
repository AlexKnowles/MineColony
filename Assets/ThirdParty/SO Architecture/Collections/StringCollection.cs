using DanielEverland.ScriptableObjectArchitecture.Utility;
using UnityEngine;

namespace DanielEverland.ScriptableObjectArchitecture.Collections
{
    [CreateAssetMenu(
    fileName = "StringCollection.asset",
    menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "string",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 2)]
    public class StringCollection : Collection<string>
    {
    }
}