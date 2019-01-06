using UnityEngine;

namespace MineColony.Game.Systems
{
    [CreateAssetMenu(menuName = "Systems/Tiles")]
    public class Tiles : ScriptableObject
    {
        public Vector3 DistanceBetweenTiles = new Vector3(1f, 1f, 1f);

        public Vector3 GetTileUnderPointer(Vector3 point)
        {
            float x = GetValueBasedOnDistance(point.x, DistanceBetweenTiles.x);
            float y = GetValueBasedOnDistance(point.y, DistanceBetweenTiles.y);
            float z = GetValueBasedOnDistance(point.z, DistanceBetweenTiles.z);

            return new Vector3(x, y, z);
        }

        public float GetValueBasedOnDistance(float value, float distance)
        {
            float closestTile = (value - (value % distance));

            if (value < 0 && value != closestTile)
            {
                closestTile -= distance;
            }

            return closestTile;
        }
    }
}
