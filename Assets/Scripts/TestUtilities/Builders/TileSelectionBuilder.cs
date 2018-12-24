using System;
using DanielEverland.ScriptableObjectArchitecture.Variables;
using MineColony.Game.Components;
using UnityEngine;

namespace MineColony.TestUtilities.Builders
{
    public class TileSelectionBuilder
    {
        private GameObject _gameObject;
        private TileSelection _tileSelection;

        public TileSelectionBuilder()
        {
            _gameObject = new GameObject();
            _tileSelection = _gameObject.AddComponent<TileSelection>();

            _tileSelection.PointerPosition = ScriptableObject.CreateInstance<Vector3Variable>();
            _tileSelection.TileSelectionTransform = _gameObject.GetComponent<Transform>();
        }

        public TileSelection Build()
        {
            return _tileSelection;
        }

        public TileSelectionBuilder AddPointerPosition(Vector3Variable pointerPosition)
        {
            _tileSelection.PointerPosition = pointerPosition;

            return this;
        }

        public TileSelectionBuilder AddTileSelectionTransform(Transform tileSelectionTransform)
        {
            _tileSelection.TileSelectionTransform = tileSelectionTransform;

            return this;
        }
    }
}