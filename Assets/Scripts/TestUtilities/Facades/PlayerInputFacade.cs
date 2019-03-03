using MineColony.Game.Interfaces;
using UnityEngine;

namespace MineColony.TestUtilities.Facades
{
    public class PlayerInputFacade : IPlayerInput
    {
        public float FixedAxisValue;
        public Vector3 FixedWorldPositionUnderMousePointer;

        public PlayerInputFacade(float fixedAxisValue, Vector3 fixedWorldPositionUnderMousePointer)
        {
            FixedAxisValue = fixedAxisValue;
            FixedWorldPositionUnderMousePointer = fixedWorldPositionUnderMousePointer;
        }

        public float GetAxis(string fullTileSelectionAxis)
        {
            return FixedAxisValue;
        }

        public Vector3 GetWorldPositionUnderMousePointer()
        {
            return FixedWorldPositionUnderMousePointer;
        }
    }
}