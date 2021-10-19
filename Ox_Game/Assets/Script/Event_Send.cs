using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Send : MonoBehaviour
{
    public delegate void Dash_Button();
    public static event Dash_Button Touch;

    public void Touch_Dash_Button()
    {
        if (Touch != null)
        {
            Touch();
        }
    }
}
