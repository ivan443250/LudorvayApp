using UnityEngine;

namespace LudMain.General
{
    public abstract class BaseRefreshIndicator : MonoBehaviour
    {
        public abstract void ShowTreshold(float currentTresholdValue);
        public abstract void Refresh();
    }
}
