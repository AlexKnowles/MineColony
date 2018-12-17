using MineColony.Game.Interfaces;
using UnityEngine;

namespace MineColony.Game.Components.Inputs
{
    public class PlayerInput : MonoBehaviour, IPlayerInput
    {
        [Range(1, 4)]
        public int PlayerNumber = 1;
        public Camera PlayerCamera;

        private string _axisPrefix;

        public void OnEnable()
        {
            _axisPrefix = string.Format("Player{0}_", PlayerNumber);
        }

        public Vector3 GetWorldPositionUnderMousePointer()
        {
            Ray rayFromPoint = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(rayFromPoint, out raycastHit))
            {
                return raycastHit.point;
            }

            return Vector3.zero;
        }

        public float GetAxis(string axisName)
        {
            string fullAxisName = (_axisPrefix + axisName);

            return Input.GetAxis(fullAxisName);
        }
    }
}