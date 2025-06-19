using UnityEngine;

namespace LudMain.MainMenu.SightSlider
{
    [CreateAssetMenu(menuName = "Assets/SliderInfo", fileName = "new SliderInfo")]
    public class SliderInfo : ScriptableObject
    {
        [SerializeField] private string _title;
        public string Title => _title;

        [SerializeField, TextArea] private string _basis;
        public string Basis => _basis;

        [SerializeField] private Sprite _imgSprite;
        public Sprite ImgSprite => _imgSprite;
    }
}
