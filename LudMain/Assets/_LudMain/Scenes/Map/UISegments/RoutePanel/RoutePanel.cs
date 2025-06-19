using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace LudMain.Map.UISegments
{
    public class RoutePanel : MonoBehaviour, IDragHandler
    {
        public UnityEvent<int> SelectRoute;

        private Animator _animator;

        private bool _isOpen = false;

        private bool _isAnimationRun = false;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetSelectedRoute(int currentRoute)
        {
            SelectRoute?.Invoke(currentRoute);
        }

        public void StartAnimation()
        {
            _isAnimationRun = true;
        }

        public void EndAnimation()
        {
            _isAnimationRun = false;
        }

        public void ChangeState()
        {
            if (_isAnimationRun) return;

            _isOpen = !_isOpen;
            _animator.SetBool(Constants.OpenBool, _isOpen);
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            if (eventData.delta.y == 0)
                return;

            if (eventData.delta.y > 0 && _isOpen == true)
                return;

            if (eventData.delta.y < 0 && _isOpen == false)
                return;

            ChangeState();
        }

        private class Constants
        {
            public const string OpenBool = "IsOpen";
        }
    }
}
