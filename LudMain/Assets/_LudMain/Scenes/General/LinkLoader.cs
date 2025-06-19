using UnityEngine;

namespace LudMain.General
{
    public class LinkLoader : MonoBehaviour
    {
        public enum LinkType
        {
            Ticket,
            Foundraising,
        }

        [SerializeField] private LinkType _linkType;

        public void OpenLink()
        {
            string link = _linkType switch
            {
                LinkType.Ticket => "https://ludorvay.ru/visit/ekskursii/",
                LinkType.Foundraising => "https://ludorvay.ru/about/index.php",
                _ => string.Empty
            };

            Application.OpenURL(link);
        }
    }
}