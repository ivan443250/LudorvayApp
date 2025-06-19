using System;
using UnityEngine;

namespace LudMain.Map.PointsOnMap
{
    public class MapPoint : MonoBehaviour
    {
        [SerializeField] private GuideScriptable _guideScriptable;
        [SerializeField] private MapPointType _type;

        public MapPointType Type => _type;

        public event Action<GuideScriptable> OnPointClick;

        private WorldCanvas _worldCanvas;

        public void Initialize()
        {
            _worldCanvas = GetComponentInChildren<WorldCanvas>();
        }

        public void SetActiveCanvas(bool isActive)
        {
            _worldCanvas.gameObject.SetActive(isActive);
        }

        public void HandleObjectClick()
        {
            OnPointClick?.Invoke(_guideScriptable);
        }
    }
}
