using DanielEverland.ScriptableObjectArchitecture.Utility;
using UnityEngine;

namespace DanielEverland.ScriptableObjectArchitecture.Variables
{
    [CreateAssetMenu(
    fileName = "DoubleVariable.asset",
    menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "double",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 8)]
    public class DoubleVariable : BaseVariable<double>
    {
    }
}