using DanielEverland.ScriptableObjectArchitecture.Variables;
using UnityEngine;

namespace MineColony.Game.Components
{
    public class TileSelection : MonoBehaviour
    {
        public Vector3Variable PointerPosition;
        public Transform TileSelectionTransform;

        private bool _selecting;
        private Vector3 _startPosition;

        private void OnEnable()
        {
            _selecting = false;
        }

        private void Update()
        {
            if(_selecting)
            {
                Vector3 selectorScale = new Vector3(PointerPosition.Value.x - _startPosition.x, PointerPosition.Value.z - _startPosition.z, 1);

                Vector3 selectorScaleHalf = (selectorScale / 2);

                TileSelectionTransform.position = new Vector3(_startPosition.x + selectorScaleHalf.x, _startPosition.y, _startPosition.z + selectorScaleHalf.y);
                
                TileSelectionTransform.localScale = selectorScale;
            }
        }

        public void Begin()
        {
            _startPosition = PointerPosition;

            _startPosition.y = 0.5001f;

            TileSelectionTransform.position = _startPosition;

            _selecting = true;
        }

        public void End()
        {

        }
    }
}
