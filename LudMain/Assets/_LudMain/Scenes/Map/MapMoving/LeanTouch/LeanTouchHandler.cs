using Lean.Touch;
using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace LudMain.Map.TouchHandler
{
    public class LeanTouchHandler : MonoBehaviour
    {
        [SerializeField] private Map _map;

        private Action<LeanFinger> OnFingerDown;
        private Action<LeanFinger> OnFingerUp;

        private void Awake()
        {
            OnFingerDown = (finger) =>
            {
                List<LeanFinger> fingers = LeanTouch.Fingers;

                if (fingers.Count == 1 && finger.IsOverGui == false)
                    _map.UpdateDefaultPosition(fingers[0]);
            };

            OnFingerUp = (fingerUp) =>
            {
                List<LeanFinger> fingers = new();

                foreach (LeanFinger finger in LeanTouch.Fingers)
                    fingers.Add(finger);

                if (fingers.Contains(fingerUp))
                    fingers.Remove(fingerUp);   

                if (fingers.Count == 1)
                    _map.UpdateDefaultPosition(fingers[0]);
            };

            LeanTouch.OnFingerDown += OnFingerDown;
            LeanTouch.OnFingerUp += OnFingerUp;
        }

        private void OnDisable()
        {
            LeanTouch.OnFingerDown -= OnFingerDown;
            LeanTouch.OnFingerUp -= OnFingerUp;
        }

        private void Update()
        {
            List<LeanFinger> fingers = new();

            foreach (LeanFinger finger in LeanTouch.Fingers)
            {
                if (finger.StartedOverGui == false)
                    fingers.Add(finger);    
            }

            if (fingers.Count == 1)
            {
                HandleOneFingerMove(fingers[0]);
                return;
            }

            if (fingers.Count == 2)
            {
                HandleTwoFingersMove(fingers);
                return;
            }
        }

        private void HandleOneFingerMove(LeanFinger finger)
        {
            Ray ray = Camera.main.ScreenPointToRay(finger.ScreenPosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _map.transform.position = hit.point;
            }
        }

        private void HandleTwoFingersMove(List<LeanFinger> fingers)
        {
            _map.SetModelScaleDelta(1 - LeanGesture.GetPinchRatio(fingers));

            _map.AddModelRotationY(-LeanGesture.GetTwistDegrees(fingers));
        }
    }
}