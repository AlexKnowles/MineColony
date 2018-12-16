using MineColony.Game.Interfaces;
using UnityEngine;

namespace MineColony.TestUtilities.Facades
{
    public class PlayerInputFacade : IPlayerInput
    {
        public float FixedAxisValue;
        public Vector3 FixedMousePointerPositionInWorldValue;

        public PlayerInputFacade(float fixedAxisValue, Vector3 fixedMousePointerPositionInWorldValue)
        {
            FixedAxisValue = fixedAxisValue;
            FixedMousePointerPositionInWorldValue = fixedMousePointerPositionInWorldValue;
        }

        public float GetAxis(string fullTileSelectionAxis)
        {
            return FixedAxisValue;
        }

        public Vector3 GetMousePointerPositionInWorld()
        {
            return FixedMousePointerPositionInWorldValue;
        }
    }
}