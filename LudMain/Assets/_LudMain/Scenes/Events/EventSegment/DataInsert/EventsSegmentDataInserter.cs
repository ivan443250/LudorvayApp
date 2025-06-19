using LudMain.General;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LudMain.Events
{
    [RequireComponent(typeof(ScrollRect))]
    public class EventsSegmentDataInserter : DataInserter<EventsSegmentData>
    {
        [Header("Set ref settings")]
        [SerializeField] private GameObject _loadingPanel;
        [SerializeField] private EventPanel _eventPanel;
        [SerializeField] private EventSegment _eventSegmentPrefab;

        [Header("Insert data settings")]
        [SerializeField] private GameObject _content;
        [SerializeField] private float _topOffset;
        [SerializeField] private float _segmentsOffset;
        [SerializeField] private float _bottomOffset;

        private List<EventSegment> _eventSegments;
        private ScrollRect _scrollRect;

        protected override void Construct()
        {
            _eventSegments = new();
            _scrollRect = GetComponent<ScrollRect>();
        }

        protected override void ShowLoading()
        {
            _loadingPanel.SetActive(true);
        }

        protected override void InsertData(EventsSegmentData data)
        {
            InsertDataToEventSegments(data);

            _loadingPanel.SetActive(false);
        }

        private void InsertDataToEventSegments(EventsSegmentData data)
        {
            int different = data.EventDatas.Length - _eventSegments.Count;

            if (different > 0)
                for (int i = 0; i < different; i++)
                    _eventSegments.Add(Instantiate(_eventSegmentPrefab, _content.transform));

            if (different < 0)
                foreach (EventSegment segment in _eventSegments)
                    segment.gameObject.SetActive(false);

            for (int i = 0; i < data.EventDatas.Length; i++)
            {
                EventSegment segment = _eventSegments[i];

                segment.gameObject.SetActive(true);
                segment.SetData(data.EventDatas[i], _eventPanel);
            }
        }

        public override HashSet<Type> GetDataLoaders()
        {
            return new HashSet<Type>() { typeof(EventsSegmentDataLoader) };
        }
    }
}