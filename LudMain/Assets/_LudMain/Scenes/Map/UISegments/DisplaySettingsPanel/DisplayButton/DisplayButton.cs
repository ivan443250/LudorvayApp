using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace LudMain.Map.UISegments
{
    public class DisplayButton : MonoBehaviour
    {
        [Header("Set references")]
        [SerializeField] private GameObject _selectedBackgroundPanel;
        [SerializeField] private TMP_Text _current;

        [Header("Set colors"), Space]
        [SerializeField] private Color _defaultColor;
        [SerializeField] private Color _selectColor;

        public void Select()
        {
            _current.color = _selectColor;
            _selectedBackgroundPanel.gameObject.SetActive(true);
        }

        public void Unselect()
        {
            _current.color = _defaultColor;
            _selectedBackgroundPanel.gameObject.SetActive(false);
        }
    }
}