using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    private Text clock;
    // Start is called before the first frame update
    void Start()
    {
        clock = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        clock.text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
    }
}
