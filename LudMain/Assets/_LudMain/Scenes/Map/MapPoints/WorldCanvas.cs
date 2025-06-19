using UnityEngine;

namespace LudMain.Map.PointsOnMap
{
    public class WorldCanvas : MonoBehaviour
    {
        private void Update()
        {
            transform.LookAt(Camera.main.transform.position);
            transform.Rotate(Vector3.up * 180);
        }
    }
}
