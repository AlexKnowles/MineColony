using DanielEverland.ScriptableObjectArchitecture.Collections;
using MineColony.TestUtilities.Builders.Components;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace MineColony.Tests.Components
{
    public class TileSelectionHighlighter_LateUpdate
    {
        [UnityTest]
        public IEnumerator NothingHappensWhenNotSelecting()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();

            selectedTiles.Add(Vector3.up);
            selectedTiles.Add(Vector3.down);
            selectedTiles.Add(Vector3.left);
            selectedTiles.Add(Vector3.right);

            TileSelectionHighlighter tileSelectionHighlighter = new TileSelectionHighlighterBuilder().AddSelectedTiles(selectedTiles)
                                                                                                     .Build();

            yield return null;

            Assert.AreEqual(Vector3.zero, tileSelectionHighlighter.Transform.position);
            Assert.AreEqual(Vector3.one, tileSelectionHighlighter.Transform.localScale);
        }


        [UnityTest]
        public IEnumerator TransformedMovedToLowestSelectedTile_Zero()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();

            selectedTiles.Add(Vector3.zero);

            TileSelectionHighlighter tileSelectionHighlighter = new TileSelectionHighlighterBuilder().AddSelectedTiles(selectedTiles)
                                                                                                     .Build();
            tileSelectionHighlighter.BeginSelection(Vector3.one);

            yield return null;

            Assert.AreEqual(Vector3.zero, tileSelectionHighlighter.Transform.position);
        }

        [UnityTest]
        public IEnumerator TransformedMovedToLowestSelectedTile_Single_Positive()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();

            selectedTiles.Add(new Vector3(65, 0, 45));

            TileSelectionHighlighter tileSelectionHighlighter = new TileSelectionHighlighterBuilder().AddSelectedTiles(selectedTiles)
                                                                                                     .Build();
            tileSelectionHighlighter.BeginSelection(Vector3.zero);

            yield return null;

            Assert.AreEqual(new Vector3(65, 0, 45), tileSelectionHighlighter.Transform.position);
        }

        [UnityTest]
        public IEnumerator TransformedMovedToLowestSelectedTile_Multiple_Positive()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();

            selectedTiles.Add(new Vector3(1, 0, 1));
            selectedTiles.Add(new Vector3(2, 0, 1));
            selectedTiles.Add(new Vector3(1, 0, 2));
            selectedTiles.Add(new Vector3(2, 0, 2));

            TileSelectionHighlighter tileSelectionHighlighter = new TileSelectionHighlighterBuilder().AddSelectedTiles(selectedTiles)
                                                                                                     .Build();
            tileSelectionHighlighter.BeginSelection(Vector3.zero);

            yield return null;

            Assert.AreEqual(new Vector3(1, 0, 1), tileSelectionHighlighter.Transform.position);
        }

        [UnityTest]
        public IEnumerator TransformedMovedToLowestSelectedTile_Single_Negative()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();

            selectedTiles.Add(new Vector3(-78, 0, -1));

            TileSelectionHighlighter tileSelectionHighlighter = new TileSelectionHighlighterBuilder().AddSelectedTiles(selectedTiles)
                                                                                                     .Build();
            tileSelectionHighlighter.BeginSelection(Vector3.zero);

            yield return null;

            Assert.AreEqual(new Vector3(-78, 0, -1), tileSelectionHighlighter.Transform.position);
        }

        [UnityTest]
        public IEnumerator TransformedMovedToLowestSelectedTile_Multiple_Negative()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();

            selectedTiles.Add(new Vector3(-12, 0, -12));
            selectedTiles.Add(new Vector3(-11, 0, -12));
            selectedTiles.Add(new Vector3(-12, 0, -11));
            selectedTiles.Add(new Vector3(-11, 0, -11));

            TileSelectionHighlighter tileSelectionHighlighter = new TileSelectionHighlighterBuilder().AddSelectedTiles(selectedTiles)
                                                                                                     .Build();
            tileSelectionHighlighter.BeginSelection(Vector3.zero);

            yield return null;

            Assert.AreEqual(new Vector3(-12, 0, -12), tileSelectionHighlighter.Transform.position);
        }


        [UnityTest]
        public IEnumerator TransformedScaledToSizeOfSelectedTiles_Zero()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();

            selectedTiles.Add(new Vector3(0, 0, 0));

            TileSelectionHighlighter tileSelectionHighlighter = new TileSelectionHighlighterBuilder().AddSelectedTiles(selectedTiles)
                                                                                                     .Build();
            tileSelectionHighlighter.BeginSelection(new Vector3(1, 0, 12));

            yield return null;

            Assert.AreEqual(new Vector3(1, 1, 1), tileSelectionHighlighter.Transform.localScale);
        }

        [UnityTest]
        public IEnumerator TransformedScaledToSizeOfSelectedTiles_Single_Positive()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();

            selectedTiles.Add(new Vector3(6, 0, 12));

            TileSelectionHighlighter tileSelectionHighlighter = new TileSelectionHighlighterBuilder().AddSelectedTiles(selectedTiles)
                                                                                                     .Build();
            tileSelectionHighlighter.BeginSelection(Vector3.zero);

            yield return null;

            Assert.AreEqual(new Vector3(1, 1, 1), tileSelectionHighlighter.Transform.localScale);
        }

        [UnityTest]
        public IEnumerator TransformedScaledToSizeOfSelectedTiles_Multiple_Positive()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();

            selectedTiles.Add(new Vector3(326, 0, 326));
            selectedTiles.Add(new Vector3(326, 0, 327));
            selectedTiles.Add(new Vector3(326, 0, 328));

            selectedTiles.Add(new Vector3(327, 0, 326));
            selectedTiles.Add(new Vector3(327, 0, 327));
            selectedTiles.Add(new Vector3(327, 0, 328));

            selectedTiles.Add(new Vector3(328, 0, 326));
            selectedTiles.Add(new Vector3(328, 0, 327));
            selectedTiles.Add(new Vector3(328, 0, 328));

            TileSelectionHighlighter tileSelectionHighlighter = new TileSelectionHighlighterBuilder().AddSelectedTiles(selectedTiles)
                                                                                                     .Build();
            tileSelectionHighlighter.BeginSelection(Vector3.zero);

            yield return null;

            Assert.AreEqual(new Vector3(3, 3, 1), tileSelectionHighlighter.Transform.localScale);
        }

        [UnityTest]
        public IEnumerator TransformedScaledToSizeOfSelectedTiles_Single_Negative()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();

            selectedTiles.Add(new Vector3(-982, 0, -23));

            TileSelectionHighlighter tileSelectionHighlighter = new TileSelectionHighlighterBuilder().AddSelectedTiles(selectedTiles)
                                                                                                     .Build();
            tileSelectionHighlighter.BeginSelection(Vector3.zero);

            yield return null;

            Assert.AreEqual(new Vector3(1, 1, 1), tileSelectionHighlighter.Transform.localScale);
        }

        [UnityTest]
        public IEnumerator TransformedScaledToSizeOfSelectedTiles_Multiple_Negative()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();

            selectedTiles.Add(new Vector3(0, 0, 0));
            selectedTiles.Add(new Vector3(0, 0, -1));
            selectedTiles.Add(new Vector3(0, 0, -2));

            selectedTiles.Add(new Vector3(-1, 0, 0));
            selectedTiles.Add(new Vector3(-1, 0, -1));
            selectedTiles.Add(new Vector3(-1, 0, -2));

            selectedTiles.Add(new Vector3(-2, 0, 0));
            selectedTiles.Add(new Vector3(-2, 0, -1));
            selectedTiles.Add(new Vector3(-2, 0, -2));

            TileSelectionHighlighter tileSelectionHighlighter = new TileSelectionHighlighterBuilder().AddSelectedTiles(selectedTiles)
                                                                                                     .Build();
            tileSelectionHighlighter.BeginSelection(Vector3.zero);

            yield return null;

            Assert.AreEqual(new Vector3(3, 3, 1), tileSelectionHighlighter.Transform.localScale);
        }

        [UnityTest]
        public IEnumerator NoUpdateAfterSelectionStops()
        {
            Vector3Collection selectedTiles = ScriptableObject.CreateInstance<Vector3Collection>();

            selectedTiles.Add(new Vector3(0, 0, 0));
            selectedTiles.Add(new Vector3(0, 0, -1));
            selectedTiles.Add(new Vector3(-1, 0, 0));
            selectedTiles.Add(new Vector3(-1, 0, -1));

            TileSelectionHighlighter tileSelectionHighlighter = new TileSelectionHighlighterBuilder().AddSelectedTiles(selectedTiles)
                                                                                                     .Build();
            tileSelectionHighlighter.BeginSelection(Vector3.zero);

            yield return null;

            selectedTiles.Add(new Vector3(1, 0, 1));
            selectedTiles.Add(new Vector3(1, 0, 2));
            selectedTiles.Add(new Vector3(1, 0, 3));

            tileSelectionHighlighter.EndSelection(new Vector3(-1, 0, -1));

            yield return null;

            Assert.AreEqual(new Vector3(-1, 0, -1), tileSelectionHighlighter.Transform.position);
            Assert.AreEqual(new Vector3(2, 2, 1), tileSelectionHighlighter.Transform.localScale);

        }
    }
}