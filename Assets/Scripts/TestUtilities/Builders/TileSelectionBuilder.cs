using DanielEverland.ScriptableObjectArchitecture.Collections;
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
            
            _tileSelection.Tiles = ScriptableObject.CreateInstance<Tiles>();
            _tileSelection.SelectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();

        }

        public TileSelection Build()
        {
            return _tileSelection;
        }

        public TileSelectionBuilder AddSelectedTiles(Vector3Collection selectedTiles)
        {
            _tileSelection.SelectedTiles = selectedTiles;

            return this;
        }
    }
}