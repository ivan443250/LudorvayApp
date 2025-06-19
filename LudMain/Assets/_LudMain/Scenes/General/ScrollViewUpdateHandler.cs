using LudMain.DataHolding;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Zenject;

namespace LudMain.General
{
    [RequireComponent(typeof(ScrollView))]
    public class ScrollViewUpdateHandler : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        protected ScrollRect Scroll;

        [Header("Refresh")]
        [SerializeField] private BaseRefreshIndicator _refreshIndicator;
        [SerializeField] private float refreshThreshold = 10f;

        private IMainDataLoader _mainDataLoader;

        private ISceneReloader _sceneReloader;

        private float _currentThreshold;

        private float _tresholdNormalize => _currentThreshold / refreshThreshold;

        [Inject]
        public void Construct(IMainDataLoader mainDataLoader, ISceneReloader sceneReloader)
        {
            _mainDataLoader = mainDataLoader;

            _sceneReloader = sceneReloader;

            Scroll = GetComponent<ScrollRect>();

            _currentThreshold = 0;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (GetScrollVerticalNormalizedPosition() != 1f ||
                _mainDataLoader.State == MainDataLoaderState.LoadingProcess)
            {
                ResetRefreshCondition();
                return;
            }

            _currentThreshold += -eventData.delta.y * Time.deltaTime;

            CheckRefreshCondition();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            ResetRefreshCondition();
        }

        private void ResetRefreshCondition()
        {
            _currentThreshold = 0;
            _refreshIndicator.ShowTreshold(_tresholdNormalize);
        }

        private void CheckRefreshCondition()
        {
            if (_currentThreshold < 0)
            {
                ResetRefreshCondition();
                return;
            }

            if (_currentThreshold >= refreshThreshold)
            {
                _currentThreshold = refreshThreshold;
                StartRefresh();
            }

            _refreshIndicator.ShowTreshold(_tresholdNormalize);
        }

        private void StartRefresh()
        {
            _refreshIndicator.Refresh();
            _sceneReloader.ReloadSceneData();
        }

        private float GetScrollVerticalNormalizedPosition()
        {
            if (Scroll.verticalNormalizedPosition == 0f && Scroll.viewport.rect.height >= Scroll.content.rect.height)
                return 1f;

            return Scroll.verticalNormalizedPosition;
        }
    }
}
