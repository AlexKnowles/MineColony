using DanielEverland.ScriptableObjectArchitecture.Utility;
using UnityEngine;

namespace DanielEverland.ScriptableObjectArchitecture.Events.GameEvents
{
    [System.Serializable]
    [CreateAssetMenu(
        fileName = "UnsignedLongGameEvent.asset",
        menuName = SOArchitecture_Utility.ADVANCED_GAME_EVENT + "ulong",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_EVENTS + 17)]
    public sealed class ULongGameEvent : GameEventBase<ulong>
    {
    }
}