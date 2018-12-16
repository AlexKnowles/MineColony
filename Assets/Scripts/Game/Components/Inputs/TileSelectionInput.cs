using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using DanielEverland.ScriptableObjectArchitecture.Variables;
using MineColony.Game.Interfaces;
using UnityEngine;

namespace MineColony.Game.Components.Inputs
{
    public class TileSelectionInput : MonoBehaviour
    {
        public PlayerInput PlayerInput;
        public IPlayerInput IPlayerInput;

        public string AxisName = "TileSelection";
        public Vector3Variable PointerPosition;

        public GameEvent OnBeginTileSelection;
        public GameEvent OnEndTileSelection;

        private bool _selectingTiles = false;

        private void Start()
        {
            if (IPlayerInput == null)
            {
                IPlayerInput = PlayerInput;
            }
        }

        private void Update()
        {
            CheckTileSelectionInput();

            if (_selectingTiles)
            {
                UpdatePointerPosition();
            }
        }

        private void CheckTileSelectionInput()
        {
            float tileSelectionAxis = IPlayerInput.GetAxis(AxisName);

            if (tileSelectionAxis > 0 && !_selectingTiles)
            {
                _selectingTiles = true;
                OnBeginTileSelection.Raise();
            }
            else if (tileSelectionAxis == 0 && _selectingTiles)
            {
                _selectingTiles = false;
                OnEndTileSelection.Raise();
            }
        }

        private void UpdatePointerPosition()
        {
            PointerPosition.Value = IPlayerInput.GetMousePointerPositionInWorld();
        }
    }
}