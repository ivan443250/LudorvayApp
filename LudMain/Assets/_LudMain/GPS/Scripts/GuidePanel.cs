using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuidePanel : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _textName;
    [SerializeField] private Image _image;

    [Space]
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _nextButton;

    [Header("Settings")]
    [SerializeField] private int _maximumInfoLettersOnPage;

    private string[] _infoPages;

    private int _currentInfoPageIndex;

    public void SetNewGuide(GuideScriptable guide)
    {
        _currentInfoPageIndex = 0;
        _infoPages = PaginateString(guide.Info, _maximumInfoLettersOnPage);

        _image.sprite = guide.Image;
        _textName.text = guide.Name;

        CorrectUI();
    }

    public void SwitchPage(int direction)
    {
        int newIndex = _currentInfoPageIndex + direction;

        if (newIndex < 0 || _currentInfoPageIndex > _infoPages.Length - 1)
            return;

        _currentInfoPageIndex = newIndex;
        CorrectUI();
    }

    private void CorrectUI()
    {
        _backButton.gameObject.SetActive(_currentInfoPageIndex != 0);
        _nextButton.gameObject.SetActive(_currentInfoPageIndex != _infoPages.Length - 1);

        _text.text = _infoPages[_currentInfoPageIndex];
    }

    private static string[] PaginateString(string str, int pageCount)
    {
        List<string> pages = new List<string>();
        int currentIndex = 0;

        while (currentIndex < str.Length)
        {
            int nextPageIndex = currentIndex + pageCount > str.Length ? str.Length : currentIndex + pageCount;
            string page = str.Substring(currentIndex, nextPageIndex - currentIndex);

            if (!page.EndsWith(" ") && nextPageIndex != str.Length)
            {
                int lastSpaceIndex = page.LastIndexOf(' ');
                if (lastSpaceIndex != -1)
                {
                    page = page.Substring(0, lastSpaceIndex + 1);
                }
            }

            pages.Add(page);
            currentIndex += page.Length;
        }

        return pages.ToArray();
    }
}
