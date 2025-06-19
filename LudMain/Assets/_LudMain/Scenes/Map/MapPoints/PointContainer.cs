using System.Collections.Generic;
using UnityEngine;

namespace LudMain.Map.PointsOnMap
{
    public class PointContainer : MonoBehaviour
    {
        [SerializeField] private MapPoint[] _mapPoints;

        [SerializeField] private GuidePanel _currentPanel;

        private Dictionary<int, MapPointType> pointTyeps = new()
        {
            { 1, MapPointType.Attraction },
            { 2, MapPointType.FuncPoint }
        };

        private void Awake()
        {
            foreach (MapPoint point in _mapPoints)
            {
                point.Initialize();
                point.OnPointClick += OpenPanel;
            }
        }

        public void ShowPoints(int pointsType)
        {
            if (pointTyeps.ContainsKey(pointsType) == false)
            {
                foreach (MapPoint point in _mapPoints)
                    point.SetActiveCanvas(true);

                return;
            }

            MapPointType currentType = pointTyeps[pointsType];
            foreach (MapPoint point in _mapPoints)
                point.SetActiveCanvas(point.Type == currentType);
        }

        private void OpenPanel(GuideScriptable guideScriptable)
        {
            _currentPanel.gameObject.SetActive(true);
            _currentPanel.SetNewGuide(guideScriptable);
        }
    }
}