using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LudMain.MainMenu.FoundRaisingSegment
{
    public class FoundraisingPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _mainTitle;
        [SerializeField] private TMP_Text _description;

        [SerializeField] private TMP_Text _collectedMoney;
        [SerializeField] private TMP_Text _needMoney;

        [SerializeField] private Image _currentPicture;
        [SerializeField] private Image _progressBar;

        public void InsertData(FoundRaisingSegmentData data)
        {
            _mainTitle.text = data.MainTitle;
            _description.text = data.Description;

            _collectedMoney.text = data.CollectedMoney.ToString();
            _needMoney.text = data.NeedMoney.ToString();

            _currentPicture.sprite = data.Sprite.Value;

            _progressBar.fillAmount = (float)data.CollectedMoney / (float)data.NeedMoney;
        }
    }
}
