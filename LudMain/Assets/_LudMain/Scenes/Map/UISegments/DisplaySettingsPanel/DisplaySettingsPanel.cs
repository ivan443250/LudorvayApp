using UnityEngine;
using UnityEngine.Events;

namespace LudMain.Map.UISegments
{
    public class DisplaySettingsPanel : MonoBehaviour
    {
        [SerializeField] private DisplayButton[] _buttons;

        [SerializeField, Space] private UnityEvent<int> _onPanelSelected;

        private int _currentButtonIndex = 0;

        private void Awake()
        {
            CorrectUI();
        }

        public void SelectButton(int index)
        {
            _currentButtonIndex = index;

            CorrectUI();

            _onPanelSelected.Invoke(index);
        }

        private void CorrectUI()
        {
            foreach (var button in _buttons)
                button.Unselect();

            _buttons[_currentButtonIndex].Select();
        }
    }
}
