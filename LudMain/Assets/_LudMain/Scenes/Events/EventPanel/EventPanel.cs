using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LudMain.Events
{
    public class EventPanel : MonoBehaviour
    {
        [Header("Set segment parts")]
        [SerializeField] private TMP_Text _mainTitle;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private TMP_Text _time;
        [SerializeField] private Image _image;

        public void SetData(EventData data)
        {
            _mainTitle.text = data.Name; 
            _description.text = data.Description;

            _time.text = data.Time;

            _image.sprite = data.Sprite.Value;
        }
    }
}
