using DanielEverland.ScriptableObjectArchitecture.Variables;
using MineColony.Game.Components.Inputs;
using MineColony.TestUtilities.Builders;
using MineColony.TestUtilities.Facades;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace MineColony.Tests.Components.Inputs
{
    public class TileSelectionInput_Update
    {
        [UnityTest]
        public IEnumerator PointerDownBeginsTileSelection()
        {
            GameEventFacade onBeginTileSelection = new GameEventFacade();
            PlayerInputFacade playerInputFacade = new PlayerInputFacade(1, Vector3.zero);

            new TileSelectionInputBuilder().AddOnBeginTileSelection(onBeginTileSelection)
                                           .AddPlayerInput(playerInputFacade)
                                           .Build();

            yield return null;

            Assert.IsTrue(onBeginTileSelection.EventWasRaised);
        }

        [UnityTest]
        public IEnumerator MultiplePointersDownOnlyBeginsTileSelectionOnce()
        {
            GameEventFacade onBeginTileSelection = new GameEventFacade();
            PlayerInputFacade playerInputFacade = new PlayerInputFacade(1, Vector3.zero);

            new TileSelectionInputBuilder().AddOnBeginTileSelection(onBeginTileSelection)
                                           .AddPlayerInput(playerInputFacade)
                                           .Build();

            yield return null;

            Assert.IsTrue(onBeginTileSelection.EventWasRaised);
            onBeginTileSelection.Reset();

            yield return null;

            Assert.IsFalse(onBeginTileSelection.EventWasRaised);

            yield return null;

            Assert.IsFalse(onBeginTileSelection.EventWasRaised);
        }

        [UnityTest]
        public IEnumerator PointerPositionUpdatedAfterOnBeginTileSelection()
        {
            GameEventFacade onBeginTileSelection = new GameEventFacade();
            PlayerInputFacade playerInputFacade = new PlayerInputFacade(1, Vector3.forward);
            Vector3Variable pointerPosition = ScriptableObject.CreateInstance<Vector3Variable>();

            new TileSelectionInputBuilder().AddOnBeginTileSelection(onBeginTileSelection)
                                           .AddPlayerInput(playerInputFacade)
                                           .AddPointerPosition(pointerPosition)
                                           .Build();

            Assert.AreEqual(new Vector3(0, 0, 0), pointerPosition.Value);

            yield return null;

            Assert.AreEqual(new Vector3(0, 0, 1), pointerPosition.Value);

            pointerPosition.Value = Vector3.zero;

            yield return null;

            Assert.AreEqual(new Vector3(0, 0, 1), pointerPosition.Value);
        }

        [UnityTest]
        public IEnumerator PointerUpEndsTileSelection()
        {
            GameEventFacade onEndTileSelection = new GameEventFacade();
            PlayerInputFacade playerInputFacade = new PlayerInputFacade(1, Vector3.zero);

            new TileSelectionInputBuilder().AddOnEndTileSelection(onEndTileSelection)
                                           .AddPlayerInput(playerInputFacade)
                                           .Build();

            yield return null;

            Assert.IsFalse(onEndTileSelection.EventWasRaised);
            playerInputFacade.FixedAxisValue = 0;

            yield return null;

            Assert.IsTrue(onEndTileSelection.EventWasRaised);
        }

        [UnityTest]
        public IEnumerator MultiplePointersUpOnlyEndsTileSelectionOnce()
        {
            GameEventFacade onEndTileSelection = new GameEventFacade();
            PlayerInputFacade playerInputFacade = new PlayerInputFacade(1, Vector3.zero);

            new TileSelectionInputBuilder().AddOnEndTileSelection(onEndTileSelection)
                                           .AddPlayerInput(playerInputFacade)
                                           .Build();
            yield return null;

            Assert.IsFalse(onEndTileSelection.EventWasRaised);
            playerInputFacade.FixedAxisValue = 0;

            yield return null;

            Assert.IsTrue(onEndTileSelection.EventWasRaised);
            onEndTileSelection.Reset();
            playerInputFacade.FixedAxisValue = 0;

            yield return null;

            Assert.IsFalse(onEndTileSelection.EventWasRaised);

            yield return null;

            Assert.IsFalse(onEndTileSelection.EventWasRaised);
        }

        [UnityTest]
        public IEnumerator PointerPositionNotUpdatedAfterOnEndTileSelection()
        {
            PlayerInputFacade playerInputFacade = new PlayerInputFacade(1, Vector3.left);
            Vector3Variable pointerPosition = ScriptableObject.CreateInstance<Vector3Variable>();

            new TileSelectionInputBuilder().AddPlayerInput(playerInputFacade)
                                           .AddPointerPosition(pointerPosition)
                                           .Build();

            yield return null;

            Assert.AreEqual(new Vector3(-1, 0, 0), pointerPosition.Value);

            pointerPosition.Value = Vector3.zero;
            playerInputFacade.FixedAxisValue = 0;

            yield return null;

            Assert.AreEqual(new Vector3(0, 0, 0), pointerPosition.Value);

            yield return null;

            Assert.AreEqual(new Vector3(0, 0, 0), pointerPosition.Value);
        }
    }
}
