using LudMain.DataHolding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace LudMain.Events
{
    [Serializable]
    public class EventsSegmentData : Data
    {
        public EventData[] EventDatas;

        public EventsSegmentData(EventData[] eventDatas)
        {
            EventDatas = eventDatas;
        }

        public override object Clone()
        {
            EventData[] cloneEventDatas = new EventData[EventDatas.Length];

            for (int i = 0; i < cloneEventDatas.Length; i++)
                cloneEventDatas[i] = EventDatas[i].Clone() as EventData;

            return new EventsSegmentData(cloneEventDatas);
        }

        public override string Serialize()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
