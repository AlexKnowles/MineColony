using DanielEverland.ScriptableObjectArchitecture.Collections;
using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MineColony.Game.Systems
{
    [CreateAssetMenu(menuName = "Systems/TileSelection")]
    public class TileSelection : ScriptableObject
    {
        public Vector3GameEvent BeginSelection;
        public Vector3GameEvent UpdateSelection;
        public Vector3GameEvent EndSelection;

        public Tiles Tiles;
        public Vector3Collection SelectedTiles;

        private Vector3 _firstSelectedTile;

        private void OnEnable()
        {
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            if (BeginSelection != null)
            {
                Vector3GameEventListenerLite beginSelectionListener = new Vector3GameEventListenerLite
                {
                    EventsToRaise = OnBegin
                };
                BeginSelection.AddListener(beginSelectionListener);
            }

            if (UpdateSelection != null)
            {
                Vector3GameEventListenerLite updateSelectionListener = new Vector3GameEventListenerLite
                {
                    EventsToRaise = OnUpdate
                };
                UpdateSelection.AddListener(updateSelectionListener);
            }

            if (EndSelection != null)
            {
                Vector3GameEventListenerLite endSelectionListener = new Vector3GameEventListenerLite
                {
                    EventsToRaise = OnEnd
                };
                EndSelection.AddListener(endSelectionListener);
            }
        }

        public void OnUpdate(Vector3 pointerPosition)
        {
            List<Vector3> tilesBetweenFirstAndPointer = GetTilesBetweenFirstAndPointer(pointerPosition);
            List<Vector3> tilesNotAlreadySelected = tilesBetweenFirstAndPointer.Where(t => !SelectedTiles.Contains(t)).ToList();

            foreach (Vector3 tile in tilesNotAlreadySelected)
            {
                SelectedTiles.Add(tile);
            }
        }

        public void OnBegin(Vector3 pointerPosition)
        {
            SelectedTiles.Clear();

            _firstSelectedTile = Tiles.GetTileUnderPointer(pointerPosition);

            SelectedTiles.Add(_firstSelectedTile);
        }

        public void OnEnd(Vector3 pointerPosition)
        {
            // Do Stuff
        }

        private List<Vector3> GetTilesBetweenFirstAndPointer(Vector3 pointerPosition)
        {
            List<Vector3> results = new List<Vector3>();
            Vector3 currentTile = new Vector3(_firstSelectedTile.x, _firstSelectedTile.y, _firstSelectedTile.z);
            Vector3 tileUnderPointer = Tiles.GetTileUnderPointer(pointerPosition);

            float xTilesBetween = (tileUnderPointer.x - currentTile.x);
            float yTilesBetween = (tileUnderPointer.y - currentTile.y);
            float zTilesBetween = (tileUnderPointer.z - currentTile.z);

            while (currentTile.x != tileUnderPointer.x)
            {
                currentTile.x += Mathf.Sign(xTilesBetween);

                while (currentTile.y != tileUnderPointer.y)
                {
                    currentTile.y += Mathf.Sign(yTilesBetween);
                    while (currentTile.z != tileUnderPointer.z)
                    {
                        currentTile.z += Mathf.Sign(zTilesBetween);

                        results.Add(new Vector3(currentTile.x, currentTile.y, currentTile.z));
                    }
                }
            }

            return results;
        }
    }
}
