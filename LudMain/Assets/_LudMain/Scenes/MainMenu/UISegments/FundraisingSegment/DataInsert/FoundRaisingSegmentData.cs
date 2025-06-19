using LudMain.DataHolding;
using System;
using UnityEngine;

namespace LudMain.MainMenu.FoundRaisingSegment
{
    [Serializable]
    public class FoundRaisingSegmentData : Data
    {
        public string MainTitle;
        public string Description;

        public int CollectedMoney;
        public int NeedMoney;

        public SerilizableSprite Sprite;

        public FoundRaisingSegmentData(string mainTitle, string description, int collectedMoney, int needMoney, SerilizableSprite sprite)
        {
            MainTitle = mainTitle;
            Description = description;
            CollectedMoney = collectedMoney;
            NeedMoney = needMoney;

            Sprite = sprite;
        }

        public override object Clone()
        {
            SerilizableSprite spriteClone = new SerilizableSprite(Sprite.X, Sprite.Y, Sprite.Bytes, Sprite.IsEmpty);

            return new FoundRaisingSegmentData(MainTitle, Description, CollectedMoney, NeedMoney, spriteClone);
        }

        public override string Serialize()
        {
            return JsonUtility.ToJson(this);
        }
    }
}