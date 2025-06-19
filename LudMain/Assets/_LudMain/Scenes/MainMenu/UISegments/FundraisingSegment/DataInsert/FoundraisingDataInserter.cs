using LudMain.General;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LudMain.MainMenu.FoundRaisingSegment
{
    public class FoundraisingDataInserter : DataInserter<FoundRaisingSegmentData>
    {
        [Header("Current data"), Space]
        [SerializeField] private TMP_Text _mainTitle;
        [SerializeField] private TMP_Text _collectedMoney;
        [SerializeField] private TMP_Text _needMoney;

        [SerializeField] private Image _currentPicture;
        [SerializeField] private Image _progressBar;

        [Header("Openable panel")]
        [SerializeField] private FoundraisingPanel _foundraisingPanel;

        [Header("Loading panel")]
        [SerializeField] private GameObject _loadingPanel;

        protected override void ShowLoading()
        {
            _loadingPanel.SetActive(true);
        }

        protected override void InsertData(FoundRaisingSegmentData data)
        {
            _mainTitle.text = data.MainTitle;

            _collectedMoney.text = data.CollectedMoney.ToString();
            _needMoney.text = data.NeedMoney.ToString();

            _progressBar.fillAmount = (float)data.CollectedMoney / (float)data.NeedMoney;

            _currentPicture.sprite = data.Sprite.Value;

            _foundraisingPanel.InsertData(data);

            _loadingPanel.SetActive(false);
        }

        public override HashSet<Type> GetDataLoaders()
        {
            return new HashSet<Type>() { typeof(FoundraisingSegmentDataLoader) };
        }
    }
}
