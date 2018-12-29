using DanielEverland.ScriptableObjectArchitecture.Collections;
using MineColony.Game.Systems;
using MineColony.TestUtilities.Builders;
using NUnit.Framework;
using UnityEngine;

namespace MineColony.Tests.Systems
{
    public class TileSelection_OnBegin
    {
        [Test]
        public void FirstTileSelectedBasedOnPointerPosition()
        {
            TileSelection tileSelection = new TileSelectionBuilder().Build();

            tileSelection.OnBegin(new Vector3(1.57825f, 0.5f, 11.63223f));
            Assert.AreEqual(new Vector3(1f, 0, 11f), tileSelection.SelectedTiles[0]);

            tileSelection.OnBegin(new Vector3(95.57825f, 2f, -15.63223f));
            Assert.AreEqual(new Vector3(95f, 2f, -16f), tileSelection.SelectedTiles[0]);

            tileSelection.OnBegin(new Vector3(-6.57825f, -11f, -7.63223f));
            Assert.AreEqual(new Vector3(-7f, -11f, -8f), tileSelection.SelectedTiles[0]);

            tileSelection.OnBegin(new Vector3(-9956.57825f, 5.32f, 7121.63223f));
            Assert.AreEqual(new Vector3(-9957f, 5f, 7121f), tileSelection.SelectedTiles[0]);
        }

        [Test]
        public void FirstTileAddedToSelectedTiles()
        {
            TileSelection tileSelection = new TileSelectionBuilder().Build();

            tileSelection.OnBegin(Vector3.zero);

            Assert.AreEqual(1, tileSelection.SelectedTiles.Count);
            Assert.AreEqual(Vector3.zero, tileSelection.SelectedTiles[0]);
        }

        [Test]
        public void SelectedTilesIsClearedOnBegin()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();
            selectedTiles.Add(Vector3.forward);
            selectedTiles.Add(Vector3.back);
            selectedTiles.Add(Vector3.left);

            TileSelection tileSelection = new TileSelectionBuilder().AddSelectedTiles(selectedTiles)
                                                                    .Build();

            tileSelection.OnBegin(Vector3.zero);

            Assert.AreEqual(1, selectedTiles.Count);
        }
    }
}
