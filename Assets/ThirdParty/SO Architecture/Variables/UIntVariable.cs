﻿using DanielEverland.ScriptableObjectArchitecture.Utility;
using UnityEngine;

namespace DanielEverland.ScriptableObjectArchitecture.Variables
{
    [CreateAssetMenu(
    fileName = "UnsignedIntVariable.asset",
    menuName = SOArchitecture_Utility.ADVANCED_VARIABLE_SUBMENU + "uint",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 16)]
    public class UIntVariable : BaseVariable<uint>
    {
    }
}