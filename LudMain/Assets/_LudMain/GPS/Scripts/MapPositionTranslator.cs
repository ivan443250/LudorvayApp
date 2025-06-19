using System.Drawing;
using UnityEngine;

public class MapPositionTranslator : MonoBehaviour
{
    [SerializeField] private Transform _leftTopBorder;
    [SerializeField] private Transform _rightBottomBorder;

    private GPS _gps;

    public bool flag = true;

    private void Start()
    {
        _gps = GetComponent<GPS>();
    }

    public Vector3 TranslatePointPosition((Vector2, Vector2) bordersOnRealMap, Vector2 currentPointOnRealMap)
    {
        if (IsUserInNeedArea() == false)
        {
            flag = false;
            Input.location.Stop();
            _gps.panelStatus.SetActive(true);
            _gps.point.SetActive(false);
        }
        else 
        { 
            _gps.point.SetActive(true); 
        }

        (float, float) percents = GetPercentsByVector(bordersOnRealMap, currentPointOnRealMap);

        return GetVectorByPercents(percents);
    }

    private (float, float) GetPercentsByVector((Vector2, Vector2) bordersOnRealMap, Vector2 currentPointOnRealMap)
    {
        (float, float) answer;
        answer.Item1 = GetPointPercentByPosition(bordersOnRealMap.Item2.x, bordersOnRealMap.Item1.x, currentPointOnRealMap.x);
        answer.Item2 = GetPointPercentByPosition(bordersOnRealMap.Item1.y, bordersOnRealMap.Item2.y, currentPointOnRealMap.y);
        return answer;
    }

    private float GetPointPercentByPosition(float firstBorder, float secondBorder, float currentPoint)
    {
        float allDistance = firstBorder - secondBorder;
        float pointDistance = currentPoint - secondBorder;

        return pointDistance / allDistance;
    }

    private Vector3 GetVectorByPercents((float, float) percents)
    {
        Vector3 answer = new Vector3(0f, 0.2f, 0f);
        answer.x = GetPointPositionByPercent(_rightBottomBorder.position.x, _leftTopBorder.position.x, percents.Item1);
        answer.z = GetPointPositionByPercent(_leftTopBorder.position.z, _rightBottomBorder.position.z, percents.Item2);
        return answer;
    }

    private float GetPointPositionByPercent(float firstBorder, float secondBorder, float percent)
    {
        float allDistance = firstBorder - secondBorder;

        return (percent * allDistance) + secondBorder;
    }

    private bool IsUserInNeedArea()
    {
        if (_gps.latitude > 56.750578f || _gps.latitude < 56.743186f || _gps.longitude > 53.063971f || _gps.longitude < 53.045375f)
        {
            _gps.point.SetActive(false);
            return false;
        }
        else
        {
            flag = true;
            return true;
        }
    }
}
