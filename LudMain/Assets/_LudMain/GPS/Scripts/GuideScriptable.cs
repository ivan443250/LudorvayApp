using UnityEngine;


[CreateAssetMenu(fileName = "Guide")]
public class GuideScriptable : ScriptableObject
{
    [TextArea(3, 100)]
    [SerializeField] private string _info;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _image;
    
    public string Info
    {
        get
        {
            return _info;
        }
    }

    public Sprite Image
    {
        get
        {
            return _image;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }
    }
}
