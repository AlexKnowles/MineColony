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

        public Vector3GameEvent OnBeginTileSelection;
        public Vector3GameEvent OnUpdateTileSelection;
        public Vector3GameEvent OnEndTileSelection;

        private bool _selectingTiles = false;
        private Vector3 _pointerPosisition
        {
            get
            {
                return IPlayerInput.GetWorldPositionUnderMousePointer();
            }
        }

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
                UpdateTileSelection();
            }
        }

        private void CheckTileSelectionInput()
        {
            float tileSelectionAxis = IPlayerInput.GetAxis(AxisName);

            if (tileSelectionAxis > 0 && !_selectingTiles)
            {
                _selectingTiles = true;
                OnBeginTileSelection.Raise(_pointerPosisition);
            }
            else if (tileSelectionAxis == 0 && _selectingTiles)
            {
                _selectingTiles = false;
                OnEndTileSelection.Raise(_pointerPosisition);
            }
        }

        private void UpdateTileSelection()
        {
            OnUpdateTileSelection.Raise(_pointerPosisition);
        }
    }
}