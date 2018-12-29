using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using MineColony.Game.ScriptableObjectArchitecture.Collections;
using System.Linq;
using UnityEngine;

namespace MineColony.Game.Systems
{
    [CreateAssetMenu(menuName = "Systems/Tiles")]
    public class Tiles : ScriptableObject
    {
        public Vector3 GetTileUnderPointer(Vector3 point)
        {
            float flooredX = Mathf.Floor(point.x);
            float flooredY = Mathf.Floor(point.y);
            float flooredZ = Mathf.Floor(point.z);
            
            return new Vector3(flooredX, flooredY, flooredZ);
        }
    }
}
