using DanielEverland.ScriptableObjectArchitecture.Collections;
using DanielEverland.ScriptableObjectArchitecture.Utility;
using MineColony.Game.Systems;
using UnityEngine;

namespace MineColony.Game.ScriptableObjectArchitecture.Collections
{
    [CreateAssetMenu(
        fileName = "TaskCollection.asset",
        menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "Task",
        order = 120)]
    public class TaskCollection : Collection<Task>
    {
    }
}