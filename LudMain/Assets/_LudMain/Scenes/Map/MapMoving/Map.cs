using Lean.Touch;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LudMain.Map
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private Transform model;

        [Header("Scale settings"), Space]
        [SerializeField] private float _maxSize;
        [SerializeField] private float _minSize;

        [SerializeField] private float _scaleChangeStep;

        private Vector3 _mapDefaultPos;

        private void Awake()
        {
            _mapDefaultPos = transform.position;
        }

        public void UpdateDefaultPosition(LeanFinger finger)
        {
            model.parent = null;

            Ray ray = Camera.main.ScreenPointToRay(finger.ScreenPosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                transform.position = hit.point;
            }

            model.parent = transform;
        }

        public void SetModelScaleDelta(float modelScaleDelta)
        {
            model.localScale += Vector3.one * modelScaleDelta;
        }

        public void ChangeMapScale(int direction)
        {
            model.localScale *= 1 + _scaleChangeStep * direction;
        }

        public void AddModelRotationY(float degrees)
        {
            model.transform.Rotate(Vector3.up * degrees);
        }

        public void ResetToDefault()
        {
            model.parent = null;
            transform.position = _mapDefaultPos;
            model.parent = transform;

            model.localPosition = Vector3.zero;
            model.localRotation = Quaternion.identity;
            model.localScale = Vector3.one;
        }

        private void LateUpdate()
        {
            if (model.localScale.x > _maxSize)
            {
                model.localScale = Vector3.one * _maxSize;
                return;
            }

            if (model.localScale.y < _minSize)
            {
                model.localScale = Vector3.one * _minSize;
                return;
            }
        }
    }
}
