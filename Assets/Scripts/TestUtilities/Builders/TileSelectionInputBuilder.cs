using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using DanielEverland.ScriptableObjectArchitecture.Variables;
using MineColony.Game.Components.Inputs;
using MineColony.TestUtilities.Facades;
using UnityEngine;

namespace MineColony.TestUtilities.Builders
{
    public class TileSelectionInputBuilder
    {
        private readonly TileSelectionInput _tileSelectionInput;

        public TileSelectionInputBuilder()
        {
            _tileSelectionInput = new GameObject().AddComponent<TileSelectionInput>();

            _tileSelectionInput.OnBeginTileSelection = ScriptableObject.CreateInstance<GameEvent>();
            _tileSelectionInput.OnEndTileSelection = ScriptableObject.CreateInstance<GameEvent>();
            _tileSelectionInput.PointerPosition = ScriptableObject.CreateInstance<Vector3Variable>();
            _tileSelectionInput.IPlayerInput = new PlayerInputFacade(0, Vector3.zero);
        }

        public TileSelectionInput Build()
        {
            return _tileSelectionInput;
        }

        public TileSelectionInputBuilder AddOnBeginTileSelection(GameEventFacade gameEventListenerFacade)
        {
            _tileSelectionInput.OnBeginTileSelection = gameEventListenerFacade.GameEvent;

            return this;
        }

        public TileSelectionInputBuilder AddOnEndTileSelection(GameEventFacade gameEventListenerFacade)
        {
            _tileSelectionInput.OnEndTileSelection = gameEventListenerFacade.GameEvent;

            return this;
        }

        public TileSelectionInputBuilder AddPlayerInput(PlayerInputFacade playerInputFacade)
        {
            _tileSelectionInput.IPlayerInput = playerInputFacade;

            return this;
        }

        public TileSelectionInputBuilder AddPointerPosition(Vector3Variable vector3Variable)
        {
            _tileSelectionInput.PointerPosition = vector3Variable;

            return this;
        }
    }
}