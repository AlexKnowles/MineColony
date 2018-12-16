using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using UnityEngine;

namespace MineColony.Game.Components.Inputs
{
    [RequireComponent(typeof(PlayerInput))]
    public class TileSelectionInput : MonoBehaviour
    {
        public string TileSelectionAxis = "TileSelection";

        public GameEvent OnBeginTileSelection;
        public GameEvent OnEndTileSelection;

        private string _fullTileSelectionAxis;
        private bool _selectingTiles = false;


        public void OnEnable()
        {
            PlayerInput playerInput = GetComponent<PlayerInput>();

            _fullTileSelectionAxis = (playerInput.AxisPrefix + TileSelectionAxis);
        }

        private void Update()
        {
            CheckTileSelectionInput();
        }

        private void CheckTileSelectionInput()
        {
            float tileSelectionAxis = Input.GetAxis(_fullTileSelectionAxis);

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
    }
}