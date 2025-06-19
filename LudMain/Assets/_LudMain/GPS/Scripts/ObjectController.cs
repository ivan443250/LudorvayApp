using System;
using UnityEngine;


public class ObjectController : MonoBehaviour
{
    public event Action OnClick;

    private void OnMouseUpAsButton()
    {
        OnClick?.Invoke();
    }
}
