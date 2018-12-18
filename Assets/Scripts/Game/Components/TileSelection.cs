using DanielEverland.ScriptableObjectArchitecture.Variables;
using UnityEngine;

namespace MineColony.Game.Components
{
    public class TileSelection : MonoBehaviour
    {
        public Vector3Variable PointerPosition;
        public Transform TileSelectionTransform;
        public bool IsSelecting { get; private set; }

        private Vector3 _snappedStartPosition;

        private void OnEnable()
        {
            IsSelecting = false;
        }

        private void Update()
        {
            if (IsSelecting)
            {
                Vector3 distanceFromStartToPointer = (PointerPosition - _snappedStartPosition);

                Vector3 snappedPointerPosition = SnapToTile(PointerPosition, distanceFromStartToPointer);

                Vector3 selectorScale = new Vector3(snappedPointerPosition.x - _snappedStartPosition.x, snappedPointerPosition.z - _snappedStartPosition.z, 1);
                               

                float x;

                if (selectorScale.x > 0)
                {
                    x = _snappedStartPosition.x;
                }
                else
                {
                    x = _snappedStartPosition.x + 1;
                    selectorScale.x -= 1;
                }

                float y;

                if (selectorScale.y > 0)
                {
                    y = _snappedStartPosition.z;
                }
                else
                {
                    y = _snappedStartPosition.z + 1;
                    selectorScale.y -= 1;
                }

                Vector3 selectorScaleHalf = (selectorScale / 2);

                TileSelectionTransform.position = new Vector3(x + selectorScaleHalf.x, _snappedStartPosition.y, y + selectorScaleHalf.y);

                TileSelectionTransform.localScale = selectorScale;
            }
        }

        public void Begin()
        {
            _snappedStartPosition = new Vector3(Mathf.Floor(PointerPosition.Value.x), PointerPosition.Value.y + 0.001f, Mathf.Floor(PointerPosition.Value.z));

            TileSelectionTransform.position = _snappedStartPosition;

            IsSelecting = true;
        }

        public void End()
        {
            IsSelecting = false;
            TileSelectionTransform.localScale = Vector3.zero;
        }

        public Vector3 SnapToTile(Vector3 currentPosition, Vector3 distanceFromStartToPointer)
        {
            float snappedX = 0;
            float snappedZ = 0;

            if (distanceFromStartToPointer.x > 0)
            {
                snappedX = Mathf.Ceil(currentPosition.x);
            }
            else
            {
                snappedX = Mathf.Floor(currentPosition.x);
            }


            if (distanceFromStartToPointer.z > 0)
            {
                snappedZ = Mathf.Ceil(currentPosition.z);
            }
            else
            {
                snappedZ = Mathf.Floor(currentPosition.z);
            }

            return new Vector3(snappedX, currentPosition.y, snappedZ);
        }
    }
}
