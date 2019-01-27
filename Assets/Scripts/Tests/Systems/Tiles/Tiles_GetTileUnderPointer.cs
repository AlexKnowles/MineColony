using MineColony.Game.Systems;
using MineColony.TestUtilities.Builders;
using NUnit.Framework;
using UnityEngine;

namespace MineColony.Tests.Systems
{
    public class Tiles_GetTileUnderPointer
    {
        [Test]
        public void OneByOneByOne_Positive()
        {
            Tiles tiles = new TilesBuilder().AddDistanceBetweenTiles(Vector3.one)
                                            .Build();

            Vector3 result = tiles.GetTileUnderPointer(new Vector3(2.3434f, 3.723123f, 9.89038f));

            Assert.AreEqual(new Vector3(2f, 3f, 9f), result);
        }

        [Test]
        public void OneByOneByOne_Negative()
        {
            Tiles tiles = new TilesBuilder().AddDistanceBetweenTiles(Vector3.one)
                                            .Build();

            Vector3 result = tiles.GetTileUnderPointer(new Vector3(-93.34224f, -12.72323f, -3.12038f));

            Assert.AreEqual(new Vector3(-94f, -13f, -4f), result);
        }

        [Test]
        public void HalfByHalfByHalf_Positive()
        {
            Tiles tiles = new TilesBuilder().AddDistanceBetweenTiles(new Vector3(0.5f, 0.5f, 0.5f))
                                            .Build();

            Vector3 result = tiles.GetTileUnderPointer(new Vector3(6.434f, 63.8213f, 9.89038f));

            Assert.AreEqual(new Vector3(6f, 63.5f, 9.5f), result);
        }

        [Test]
        public void HalfByHalfByHalf_Negative()
        {
            Tiles tiles = new TilesBuilder().AddDistanceBetweenTiles(new Vector3(0.5f, 0.5f, 0.5f))
                                            .Build();

            Vector3 result = tiles.GetTileUnderPointer(new Vector3(-42.213f, -11.9464f, -88.1234f));

            Assert.AreEqual(new Vector3(-42.5f, -12f, -88.5f), result);
        }
    }
}