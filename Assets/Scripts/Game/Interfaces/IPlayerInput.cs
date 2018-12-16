using UnityEngine;

namespace MineColony.Game.Interfaces
{
    public interface IPlayerInput
    {
        Vector3 GetMousePointerPositionInWorld();
        float GetAxis(string fullTileSelectionAxis);
    }
}