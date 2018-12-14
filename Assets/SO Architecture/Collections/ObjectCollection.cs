using DanielEverland.ScriptableObjectArchitecture.Utility;
using UnityEngine;

namespace DanielEverland.ScriptableObjectArchitecture.Collections
{
    [CreateAssetMenu(
    fileName = "ObjectCollection.asset",
    menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "Object",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 1)]
    public class ObjectCollection : Collection<Object>
    {
    }
}