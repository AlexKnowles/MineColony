using DanielEverland.ScriptableObjectArchitecture.Collections;
using MineColony.Game.Systems;
using System.Linq;
using UnityEngine;

public class TileSelectionHighlighter : MonoBehaviour
{
    public Tiles Tiles;
    public Vector3Collection SelectedTiles;
    public Transform Transform;

    private bool _selecting;

    public void BeginSelection(Vector3 tilePosition)
    {
        _selecting = true;

        Transform.position = Tiles.GetTilePositionInWorld(tilePosition);
    }

    public void EndSelection(Vector3 tilePosition)
    {
        _selecting = false;
    }

    private void LateUpdate()
    {
        if (_selecting)
        {
            Vector3 minTileSelected = SelectedTiles.OrderBy(st => st.x)
                                                   .ThenBy(st => st.y)
                                                   .ThenBy(st => st.z)
                                                   .FirstOrDefault();

            Vector3 maxTileSelected = SelectedTiles.OrderByDescending(st => st.x)
                                                   .ThenByDescending(st => st.y)
                                                   .ThenByDescending(st => st.z)
                                                   .FirstOrDefault();

            Vector3 minPosition = Tiles.GetTilePositionInWorld(minTileSelected);
            Vector3 maxPosition = Tiles.GetTilePositionInWorld(maxTileSelected);

            PositionModelToShowSelection(minPosition);
            ResizeModelToShowSelection(minPosition, maxPosition);
        }
    }

    private void PositionModelToShowSelection(Vector3 minPosition)
    {
        transform.position = minPosition;
    }

    private void ResizeModelToShowSelection(Vector3 minPosition, Vector3 maxPosition)
    {

        float x = GetAxisScaleFromMinMax(minPosition.x, maxPosition.x);
        float y = GetAxisScaleFromMinMax(minPosition.z, maxPosition.z);
        float z = GetAxisScaleFromMinMax(minPosition.y, maxPosition.y);

        Vector3 newScale = new Vector3(x, y, z);

        Transform.localScale = newScale;
    }

    private float GetAxisScaleFromMinMax(float min, float max)
    {
        float result = (max - min) + 1;

        return result;
    }
}
