using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateTimeTest : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(DateTime.UtcNow.ToString());
    }
}
