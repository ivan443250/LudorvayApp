using UnityEngine;

namespace LudMain.General
{
    [RequireComponent(typeof(Animator))]
    public class LoadingSpinner : BaseRefreshIndicator
    {
        private Animator _animator;

        private bool _inRefreshProcess;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _animator.speed = 0f;
        }

        public override void ShowTreshold(float currentTresholdValue)
        {
            if (_inRefreshProcess)
                return;

            _animator.Play("Swipe", 0, currentTresholdValue);
        }

        public override void Refresh()
        {
            _inRefreshProcess = true;
            _animator.speed = 1f;
            _animator.Play("Refresh", 0, 0);
        }

        public void EndRefresh()
        {
            _animator.speed = 0f;
            _animator.Play("Closed", 0, 0);
            _inRefreshProcess = false;
        }
    }
}