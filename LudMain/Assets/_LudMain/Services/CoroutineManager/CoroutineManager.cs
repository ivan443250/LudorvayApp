using UnityEngine;

namespace LudMain
{
    public class CoroutineManager : MonoBehaviour, ICoroutineManager 
    {
        private static CoroutineManager _instance;

        public static CoroutineManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject instanceObj = new GameObject("CoroutineManager");
                    DontDestroyOnLoad(instanceObj);
                    _instance = instanceObj.AddComponent<CoroutineManager>();
                }

                return _instance;
            }
        }
    }
}
