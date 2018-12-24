using DanielEverland.ScriptableObjectArchitecture.Variables;
using MineColony.Game.Components;
using MineColony.TestUtilities.Builders;
using NUnit.Framework;
using UnityEngine;

namespace MineColony.Tests.Components
{
    public class TileSelection_Begin
    {
        [Test]
        public void SelectionIsStarted()
        {
            TileSelection tileSelection = new TileSelectionBuilder().Build();

            tileSelection.Begin();

            Assert.IsTrue(tileSelection.IsSelecting);
        }


        [Test]
        public void StartingPoitionSetBasedOnPointerPosition()
        {
            Vector3Variable pointerPosition = ScriptableObject.CreateInstance<Vector3Variable>();
            Transform tileSelectionTransform = new GameObject().GetComponent<Transform>();

            TileSelection tileSelection = new TileSelectionBuilder().AddPointerPosition(pointerPosition)
                                                                    .AddTileSelectionTransform(tileSelectionTransform)
                                                                    .Build();

            pointerPosition.Value = new Vector3(1.57825f, 0.5f, 11.63223f);
            tileSelection.Begin();
            Assert.AreEqual(new Vector3(1f, 0.501f, 11f), tileSelection.TileSelectionTransform.position);
            
            pointerPosition.Value = new Vector3(95.57825f, 2f, -15.63223f);
            tileSelection.Begin();
            Assert.AreEqual(new Vector3(95f, 2.001f, -16f), tileSelection.TileSelectionTransform.position);

            pointerPosition.Value = new Vector3(-6.57825f, 11f, -7.63223f);
            tileSelection.Begin();
            Assert.AreEqual(new Vector3(-7f, 11.001f, -8f), tileSelection.TileSelectionTransform.position);

            pointerPosition.Value = new Vector3(-9956.57825f, 5.32f, 7121.63223f);
            tileSelection.Begin();
            Assert.AreEqual(new Vector3(-9957f, 5.321f, 7121f), tileSelection.TileSelectionTransform.position);
        }
    }
}
