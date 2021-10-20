using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Manager : MonoBehaviour
{
    public static Event_Manager Instance = new Event_Manager();

    public delegate void Dash_Button();
    public static event Dash_Button Touch_Event;

    public  delegate void Be_Catch();
    public static event Be_Catch Gameover_Event;

    public void Touch_Dash_Button()
    {
        Touch_Event?.Invoke();
    }

    public void Game_over()
    {
        Gameover_Event?.Invoke();
    }
}
