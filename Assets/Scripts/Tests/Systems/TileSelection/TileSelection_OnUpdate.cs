using DanielEverland.ScriptableObjectArchitecture.Collections;
using MineColony.Game.Systems;
using MineColony.TestUtilities.Builders;
using NUnit.Framework;
using UnityEngine;

namespace MineColony.Tests.Systems
{
    public class TileSelection_OnUpdate
    {
        [Test]
        public void SingleTileSelectedWhenInitialPointDoesntChange()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();
            selectedTiles.Add(new Vector3(1f, 0f, 11f));

            TileSelection tileSelection = new TileSelectionBuilder().AddSelectedTiles(selectedTiles)
                                                                    .Build();

            tileSelection.OnUpdate(new Vector3(1f, 0f, 11f));

            Assert.AreEqual(1, selectedTiles.Count);
            Assert.AreEqual(new Vector3(1f, 0f, 11f), selectedTiles[0]);
        }

        [Test]
        public void MultipleTilesSelected_XShiftPositive()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();
            selectedTiles.Add(new Vector3(1f, 0f, 11f));

            TileSelection tileSelection = new TileSelectionBuilder().AddSelectedTiles(selectedTiles)
                                                                    .Build();

            tileSelection.OnUpdate(new Vector3(3f, 0f, 11f));

            Assert.AreEqual(3, selectedTiles.Count);
            Assert.AreEqual(new Vector3(1f, 0f, 11f), selectedTiles[0]);
            Assert.AreEqual(new Vector3(2f, 0f, 11f), selectedTiles[1]);
            Assert.AreEqual(new Vector3(3f, 0f, 11f), selectedTiles[2]);
        }

        [Test]
        public void MultipleTilesSelected_XShiftNegative()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();
            selectedTiles.Add(new Vector3(3f, 0f, 11f));

            TileSelection tileSelection = new TileSelectionBuilder().AddSelectedTiles(selectedTiles)
                                                                    .Build();

            tileSelection.OnUpdate(new Vector3(1f, 0f, 11f));

            Assert.AreEqual(3, selectedTiles.Count);
            Assert.AreEqual(new Vector3(3f, 0f, 11f), selectedTiles[0]);
            Assert.AreEqual(new Vector3(2f, 0f, 11f), selectedTiles[1]);
            Assert.AreEqual(new Vector3(1f, 0f, 11f), selectedTiles[2]);
        }

        [Test]
        public void MultipleTilesSelected_YShiftPositive()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();
            selectedTiles.Add(new Vector3(2f, 2f, 11f));

            TileSelection tileSelection = new TileSelectionBuilder().AddSelectedTiles(selectedTiles)
                                                                    .Build();

            tileSelection.OnUpdate(new Vector3(2f, 4f, 11f));

            Assert.AreEqual(3, selectedTiles.Count);
            Assert.AreEqual(new Vector3(2f, 2f, 11f), selectedTiles[0]);
            Assert.AreEqual(new Vector3(2f, 3f, 11f), selectedTiles[1]);
            Assert.AreEqual(new Vector3(2f, 4f, 11f), selectedTiles[2]);
        }

        [Test]
        public void MultipleTilesSelected_YShiftNegative()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();
            selectedTiles.Add(new Vector3(2f, -9f, 11f));

            TileSelection tileSelection = new TileSelectionBuilder().AddSelectedTiles(selectedTiles)
                                                                    .Build();

            tileSelection.OnUpdate(new Vector3(2f, -11f, 11f));

            Assert.AreEqual(3, selectedTiles.Count);
            Assert.AreEqual(new Vector3(2f, -9f, 11f), selectedTiles[0]);
            Assert.AreEqual(new Vector3(2f, -10f, 11f), selectedTiles[1]);
            Assert.AreEqual(new Vector3(2f, -11f, 11f), selectedTiles[2]);
        }

        [Test]
        public void MultipleTilesSelected_ZShiftPositive()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();
            selectedTiles.Add(new Vector3(1f, 1f, 321f));

            TileSelection tileSelection = new TileSelectionBuilder().AddSelectedTiles(selectedTiles)
                                                                    .Build();

            tileSelection.OnUpdate(new Vector3(1f, 1f, 323f));

            Assert.AreEqual(3, selectedTiles.Count);
            Assert.AreEqual(new Vector3(1f, 1f, 321f), selectedTiles[0]);
            Assert.AreEqual(new Vector3(1f, 1f, 322f), selectedTiles[1]);
            Assert.AreEqual(new Vector3(1f, 1f, 323f), selectedTiles[2]);
        }

        [Test]
        public void MultipleTilesSelected_ZShiftNegative()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();
            selectedTiles.Add(new Vector3(1f, 1f, 1f));

            TileSelection tileSelection = new TileSelectionBuilder().AddSelectedTiles(selectedTiles)
                                                                    .Build();

            tileSelection.OnUpdate(new Vector3(1f, 1f, -1f));

            Assert.AreEqual(3, selectedTiles.Count);
            Assert.AreEqual(new Vector3(1f, 1f, 1f), selectedTiles[0]);
            Assert.AreEqual(new Vector3(1f, 1f, 0f), selectedTiles[1]);
            Assert.AreEqual(new Vector3(1f, 1f, -1f), selectedTiles[2]);
        }

        [Test]
        public void MultipleTilesSelected_TwoByTwoByTwoGrid_Positive()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();
            selectedTiles.Add(new Vector3(0f, 0f, 0f));

            TileSelection tileSelection = new TileSelectionBuilder().AddSelectedTiles(selectedTiles)
                                                                    .Build();

            tileSelection.OnUpdate(new Vector3(1f, 1f, 1f));

            Assert.AreEqual(8, selectedTiles.Count);
            
            Assert.AreEqual(new Vector3(0f, 0f, 0f), selectedTiles[0]);
            Assert.AreEqual(new Vector3(0f, 0f, 1f), selectedTiles[1]);
            Assert.AreEqual(new Vector3(0f, 1f, 0f), selectedTiles[2]);
            Assert.AreEqual(new Vector3(0f, 1f, 1f), selectedTiles[3]);
            Assert.AreEqual(new Vector3(1f, 0f, 0f), selectedTiles[4]);
            Assert.AreEqual(new Vector3(1f, 0f, 1f), selectedTiles[5]);
            Assert.AreEqual(new Vector3(1f, 1f, 0f), selectedTiles[6]);
            Assert.AreEqual(new Vector3(1f, 1f, 1f), selectedTiles[7]);

        }

        [Test]
        public void MultipleTilesSelected_TwoByTwoByTwoGrid_Negative()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();
            selectedTiles.Add(new Vector3(1f, 1f, 1f));

            TileSelection tileSelection = new TileSelectionBuilder().AddSelectedTiles(selectedTiles)
                                                                    .Build();

            tileSelection.OnUpdate(new Vector3(0f, 0f, 0f));

            Assert.AreEqual(8, selectedTiles.Count);

            Assert.AreEqual(new Vector3(1f, 1f, 1f), selectedTiles[0]);
            Assert.AreEqual(new Vector3(1f, 1f, 0f), selectedTiles[1]);
            Assert.AreEqual(new Vector3(1f, 0f, 1f), selectedTiles[2]);
            Assert.AreEqual(new Vector3(1f, 0f, 0f), selectedTiles[3]);
            Assert.AreEqual(new Vector3(0f, 1f, 1f), selectedTiles[4]);
            Assert.AreEqual(new Vector3(0f, 1f, 0f), selectedTiles[5]);
            Assert.AreEqual(new Vector3(0f, 0f, 1f), selectedTiles[6]);
            Assert.AreEqual(new Vector3(0f, 0f, 0f), selectedTiles[7]);

        }
    }
}
