using LudMain.DataHolding;
using System;
using UnityEngine;

namespace LudMain.Events
{
    [Serializable]
    public class EventData 
    {
        public string Name;
        public string Description;

        public string Date;
        public string Time;

        public SerilizableSprite Sprite;

        public EventData(string name, string description, string date, string time, SerilizableSprite sprite)
        {
            Name = name;
            Description = description;
            Date = date;
            Time = time;

            Sprite = sprite;
        }

        public object Clone()
        {
            SerilizableSprite spriteClone = new SerilizableSprite(Sprite.X, Sprite.Y, Sprite.Bytes, Sprite.IsEmpty);

            return new EventData(Name, Description, Date, Time, spriteClone);
        }

        public string Serialize()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
