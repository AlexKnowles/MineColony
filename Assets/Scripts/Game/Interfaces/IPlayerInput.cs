using UnityEngine;

namespace MineColony.Game.Interfaces
{
    public interface IPlayerInput
    {
        Vector3 GetWorldPositionUnderMousePointer();
        float GetAxis(string fullTileSelectionAxis);
    }
}