using System.Collections;
using UnityEngine;

namespace LudMain
{
    public interface ICoroutineManager
    {
        Coroutine StartCoroutine(IEnumerator routine);
        void StopCoroutine(Coroutine routine);
    }
}