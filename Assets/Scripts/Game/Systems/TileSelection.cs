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

        public Vector3 FirstSelectedTile
        {
            get
            {
                return SelectedTiles[0];
            }
        }

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

        public void OnBegin(Vector3 pointerPosition)
        {
            SelectedTiles.Clear();

            Vector3 initalTileClick = Tiles.GetTileUnderPointer(pointerPosition);
            SelectedTiles.Add(initalTileClick);
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

        public void OnEnd(Vector3 pointerPosition)
        {
            // Do Stuff
        }

        private List<Vector3> GetTilesBetweenFirstAndPointer(Vector3 pointerPosition)
        {
            List<Vector3> results = new List<Vector3>();
            Vector3 tileUnderPointer = Tiles.GetTileUnderPointer(pointerPosition);


            float xChange = Mathf.Sign(tileUnderPointer.x - FirstSelectedTile.x);
            float yChange = Mathf.Sign(tileUnderPointer.y - FirstSelectedTile.y);
            float zChange = Mathf.Sign(tileUnderPointer.z - FirstSelectedTile.z);

            float xMaxMin = (tileUnderPointer.x + xChange);
            float yMaxMin = (tileUnderPointer.y + yChange);
            float zMaxMin = (tileUnderPointer.z + zChange);

            for (float x = FirstSelectedTile.x; x != xMaxMin; x += xChange)
            {
                for (float y = FirstSelectedTile.y; y != yMaxMin; y += yChange)
                {
                    for (float z = FirstSelectedTile.z; z != zMaxMin; z += zChange)
                    {
                        results.Add(new Vector3(x, y, z));
                    }
                }
            }
                       

            return results;
        }
    }
}
