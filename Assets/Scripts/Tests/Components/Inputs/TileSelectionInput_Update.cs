using DanielEverland.ScriptableObjectArchitecture.Variables;
using MineColony.TestUtilities.Builders;
using MineColony.TestUtilities.Facades;
using MineColony.TestUtilities.Facades.Events;
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
            Vector3GameEventFacade onBeginTileSelection = new Vector3GameEventFacade();
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
            Vector3GameEventFacade onBeginTileSelection = new Vector3GameEventFacade();
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
        public IEnumerator PointerUpEndsTileSelection()
        {
            Vector3GameEventFacade onEndTileSelection = new Vector3GameEventFacade();
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
            Vector3GameEventFacade onEndTileSelection = new Vector3GameEventFacade();
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
        public IEnumerator PointerPositionUpdatedAfterOnBeginTileSelection()
        {
            PlayerInputFacade playerInputFacade = new PlayerInputFacade(1, Vector3.up);
            Vector3GameEventFacade OnUpdateTileSelection = new Vector3GameEventFacade();

            new TileSelectionInputBuilder().AddPlayerInput(playerInputFacade)
                                           .AddOnUpdateTileSelection(OnUpdateTileSelection)
                                           .Build();

            yield return null;

            Assert.IsTrue(OnUpdateTileSelection.EventWasRaised);
            Assert.AreEqual(new Vector3(0, 1, 0), OnUpdateTileSelection.EventRaisedValue);

            OnUpdateTileSelection.Reset();
            playerInputFacade.FixedWorldPositionUnderMousePointer = Vector3.left;

            yield return null;

            Assert.IsTrue(OnUpdateTileSelection.EventWasRaised);
            Assert.AreEqual(new Vector3(-1, 0, 0), OnUpdateTileSelection.EventRaisedValue);
            
            OnUpdateTileSelection.Reset();
            playerInputFacade.FixedWorldPositionUnderMousePointer = Vector3.forward;

            yield return null;

            Assert.IsTrue(OnUpdateTileSelection.EventWasRaised);
            Assert.AreEqual(new Vector3(0, 0, 1), OnUpdateTileSelection.EventRaisedValue);
        }

        [UnityTest]
        public IEnumerator PointerPositionNotUpdatedAfterOnEndTileSelection()
        {
            PlayerInputFacade playerInputFacade = new PlayerInputFacade(1, Vector3.left);
            Vector3GameEventFacade OnUpdateTileSelection = new Vector3GameEventFacade();

            new TileSelectionInputBuilder().AddPlayerInput(playerInputFacade)
                                           .AddOnUpdateTileSelection(OnUpdateTileSelection)
                                           .Build();

            yield return null;

            Assert.IsTrue(OnUpdateTileSelection.EventWasRaised);
            Assert.AreEqual(new Vector3(-1, 0, 0), OnUpdateTileSelection.EventRaisedValue);

            OnUpdateTileSelection.Reset();
            playerInputFacade.FixedAxisValue = 0;

            yield return null;

            Assert.IsFalse(OnUpdateTileSelection.EventWasRaised);

            yield return null;

            Assert.IsFalse(OnUpdateTileSelection.EventWasRaised);
        }
    }
}
