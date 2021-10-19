using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static float Speed = 5 ;
    private void Update()
    {
       Manager.Speed += Time.deltaTime;
    }
}
