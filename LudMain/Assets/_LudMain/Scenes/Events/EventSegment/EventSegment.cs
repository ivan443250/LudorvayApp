using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LudMain.Events
{
    public class EventSegment : MonoBehaviour
    {
        [Header("Set segment parts")]
        [SerializeField] private TMP_Text _mainTitle;
        [SerializeField] private TMP_Text _date;
        [SerializeField] private Image _image;

        private EventPanel _eventPanel;

        private EventData _currentData;

        public void SetData(EventData data, EventPanel eventPanel)
        {
            _currentData = data;

            _mainTitle.text = data.Name;
            _date.text = data.Date;

            _image.sprite = data.Sprite.Value;

            _eventPanel = eventPanel;
        }

        public void OpenPanel()
        {
            _eventPanel.gameObject.SetActive(true);
            _eventPanel.SetData(_currentData);
        }
    }
}
