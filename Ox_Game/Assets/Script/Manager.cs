using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static float Character_Speed = 5;
    private void Start()
    {
        InvokeRepeating("Speed_Plus", 3.0f, 3.0f);
    }
    void Speed_Plus()
    {
        Manager.Character_Speed += 1;
    }
}
