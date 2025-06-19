using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LudMain.MainMenu.SightSlider
{
    public class SightSliderPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _basis;
        [SerializeField] private Image _picture;

        private SliderInfo _current;

        public void AddInfo(SliderInfo current)
        {
            _current = current;

            _title.text = _current.Title;
            _basis.text = _current.Basis;

            _picture.sprite = _current.ImgSprite;
        }
    }
}
