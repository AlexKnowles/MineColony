using DanielEverland.ScriptableObjectArchitecture.Collections;
using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using MineColony.Game.Systems;
using UnityEngine;

namespace MineColony.TestUtilities.Builders
{
    public class TileSelectionBuilder
    {
        private TileSelection _tileSelection;

        public TileSelectionBuilder()
        {
            _tileSelection = ScriptableObject.CreateInstance<TileSelection>();

            _tileSelection.BeginSelection = ScriptableObject.CreateInstance<Vector3GameEvent>();
            _tileSelection.UpdateSelection = ScriptableObject.CreateInstance<Vector3GameEvent>();
            _tileSelection.EndSelection = ScriptableObject.CreateInstance<Vector3GameEvent>();

            _tileSelection.Tiles = ScriptableObject.CreateInstance<Tiles>();
            _tileSelection.SelectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();

        }

        public TileSelection Build()
        {
            return _tileSelection;
        }

        public TileSelectionBuilder AddBeginSelection(Vector3GameEvent beginSelection)
        {
            _tileSelection.BeginSelection = beginSelection;

            return this;
        }

        public TileSelectionBuilder AddUpdateSelection(Vector3GameEvent updateSelection)
        {
            _tileSelection.UpdateSelection = updateSelection;

            return this;
        }

        public TileSelectionBuilder AddEndSelection(Vector3GameEvent endSelection)
        {
            _tileSelection.EndSelection = endSelection;

            return this;
        }

        public TileSelectionBuilder AddSelectedTiles(Vector3Collection selectedTiles)
        {
            _tileSelection.SelectedTiles = selectedTiles;

            return this;
        }
    }
}