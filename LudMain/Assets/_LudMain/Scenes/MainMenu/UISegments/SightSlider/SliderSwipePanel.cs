using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LudMain.MainMenu.SightSlider
{
    public class SliderSwipePanel : MonoBehaviour, IDragHandler
    {
        [SerializeField] private SightSlider _slider;

        public void OnDrag(PointerEventData eventData)
        {
            if (Math.Abs(eventData.delta.x) <= Math.Abs(eventData.delta.y)) return;

            if (eventData.delta.x > 0)
                _slider.LeftFlipThrough();
            else
                _slider.RightFlipThrough();
        }
    }
}
