using UnityEngine;

namespace LudMain.MainMenu.SightSlider
{
    public class SightSlider : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] private SightSliderPanel _left;
        [SerializeField] private SightSliderPanel _middle;
        [SerializeField] private SightSliderPanel _right;

        [Header("Info")]
        [SerializeField] private SliderInfo[] _infos;

        private int _currentInfoIndex;

        private bool _inSwipe;

        private Animator _anim;

        private void Start()
        {
            _currentInfoIndex = 0;
            _anim = GetComponent<Animator>();

            _middle.AddInfo(_infos[_currentInfoIndex]);
        }

        public void EndSwipe()
        {
            _middle.AddInfo(_infos[_currentInfoIndex]);
            _inSwipe = false;
        }

        public void RightFlipThrough()
        {
            FlipThrough(Constants.Rigth, _right, 1);
        }

        public void LeftFlipThrough() 
        {
            FlipThrough(Constants.Left, _left, -1);
        }

        private void FlipThrough(string triggerName, SightSliderPanel currentPanel, int direction)
        {
            if (_inSwipe) return;

            SetInfoIndex(direction);

            currentPanel.AddInfo(_infos[_currentInfoIndex]);
            _anim.SetTrigger(triggerName);
            _inSwipe = true;
        }

        private void SetInfoIndex(int direction)
        {
            _currentInfoIndex += direction;

            if (_currentInfoIndex < 0)
                _currentInfoIndex = _infos.Length - 1;

            if (_currentInfoIndex >= _infos.Length)
                _currentInfoIndex = 0;
        }

        private class Constants
        {
            public const string Rigth = "RightSwipe";
            public const string Left = "LeftSwipe";
            public const string Idle = "Idle";
        }
    }
}