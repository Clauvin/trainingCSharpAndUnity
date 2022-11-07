using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    public event EventHandler<string> taking_care_of_events;

    // Start is called before the first frame update
    void Start()
    {
        EventHandler<string> look_a_string = (sender, the_string) =>
        {
            Debug.Log(sender.ToString() + " " + the_string);
        };
        taking_care_of_events += look_a_string;
    }

    // Update is called once per frame
    void Update()
    {
        taking_care_of_events?.Invoke(this, "a");
    }
}
