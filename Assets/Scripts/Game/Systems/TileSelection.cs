﻿using DanielEverland.ScriptableObjectArchitecture.Collections;
using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MineColony.Game.Systems
{
    [CreateAssetMenu(menuName = "Systems/TileSelection")]
    public class TileSelection : ScriptableObject
    {
        public Tiles Tiles;
        public Vector3Collection SelectedTiles;

        public Vector3 FirstSelectedTile
        {
            get
            {
                return SelectedTiles[0];
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

            SelectedTiles.Clear();

            AddTilesJustSelected(tilesBetweenFirstAndPointer);
            RemoveTilesThatAreNoLongerSelected(tilesBetweenFirstAndPointer);
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
        
        private void AddTilesJustSelected(List<Vector3> tilesBetweenFirstAndPointer)
        {
            foreach (Vector3 tile in tilesBetweenFirstAndPointer)
            {
                if (!SelectedTiles.Contains(tile))
                {
                    SelectedTiles.Add(tile);
                }
            }
        }

        private void RemoveTilesThatAreNoLongerSelected(List<Vector3> tilesBetweenFirstAndPointer)
        {
            for (int i = (SelectedTiles.Count - 1); i >= 0; i--)
            {
                Vector3 tile = SelectedTiles[i];

                if (!tilesBetweenFirstAndPointer.Contains(tile))
                {
                    SelectedTiles.Remove(tile);
                }
            }
        }
    }
}
