using DanielEverland.ScriptableObjectArchitecture.Collections;
using MineColony.Game.Systems;
using UnityEngine;

namespace MineColony.TestUtilities.Builders.Components
{
    public class TileSelectionHighlighterBuilder
    {
        private TileSelectionHighlighter _tileSelectionHighlighter;
        private GameObject _gameObject;

        public TileSelectionHighlighterBuilder()
        {
            _gameObject = new GameObject();
            _tileSelectionHighlighter = _gameObject.AddComponent<TileSelectionHighlighter>();

            _tileSelectionHighlighter.Tiles = ScriptableObject.CreateInstance<Tiles>();
            _tileSelectionHighlighter.SelectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();
            _tileSelectionHighlighter.Transform = _gameObject.transform;

        }

        public TileSelectionHighlighter Build()
        {
            return _tileSelectionHighlighter;
        }

        public TileSelectionHighlighterBuilder AddSelectedTiles(Vector3Collection selectedTiles)
        {
            _tileSelectionHighlighter.SelectedTiles = selectedTiles;

            return this;
        }
    }
}