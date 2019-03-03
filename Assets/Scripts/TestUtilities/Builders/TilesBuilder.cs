using UnityEngine;
using System.Collections;
using MineColony.Game.Systems;

namespace MineColony.TestUtilities.Builders
{
    public class TilesBuilder
    {
        private Tiles _tiles;

        public TilesBuilder()
        {
            _tiles = ScriptableObject.CreateInstance<Tiles>();
        }

        public Tiles Build()
        {
            return _tiles;
        }

        public TilesBuilder AddDistanceBetweenTiles(Vector3 distanceBetweenTiles)
        {
            _tiles.DistanceBetweenTiles = distanceBetweenTiles;

            return this;
        }
    }
}