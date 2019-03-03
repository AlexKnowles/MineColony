using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using DanielEverland.ScriptableObjectArchitecture.Variables;
using MineColony.Game.Components.Inputs;
using MineColony.TestUtilities.Facades;
using MineColony.TestUtilities.Facades.Events;
using UnityEngine;

namespace MineColony.TestUtilities.Builders
{
    public class TileSelectionInputBuilder
    {
        private readonly TileSelectionInput _tileSelectionInput;

        public TileSelectionInputBuilder()
        {
            _tileSelectionInput = new GameObject().AddComponent<TileSelectionInput>();

            _tileSelectionInput.OnBeginTileSelection = ScriptableObject.CreateInstance<Vector3GameEvent>();
            _tileSelectionInput.OnUpdateTileSelection = ScriptableObject.CreateInstance<Vector3GameEvent>();
            _tileSelectionInput.OnEndTileSelection = ScriptableObject.CreateInstance<Vector3GameEvent>();

            _tileSelectionInput.IPlayerInput = new PlayerInputFacade(0, Vector3.zero);
        }

        public TileSelectionInput Build()
        {
            return _tileSelectionInput;
        }

        public TileSelectionInputBuilder AddOnBeginTileSelection(Vector3GameEventFacade gameEventListenerFacade)
        {
            _tileSelectionInput.OnBeginTileSelection = gameEventListenerFacade.GameEvent;

            return this;
        }

        public TileSelectionInputBuilder AddOnEndTileSelection(Vector3GameEventFacade gameEventListenerFacade)
        {
            _tileSelectionInput.OnEndTileSelection = gameEventListenerFacade.GameEvent;

            return this;
        }

        public TileSelectionInputBuilder AddOnUpdateTileSelection(Vector3GameEventFacade gameEventListenerFacade)
        {
            _tileSelectionInput.OnUpdateTileSelection = gameEventListenerFacade.GameEvent;

            return this;
        }

        public TileSelectionInputBuilder AddPlayerInput(PlayerInputFacade playerInputFacade)
        {
            _tileSelectionInput.IPlayerInput = playerInputFacade;

            return this;
        }
    }
}