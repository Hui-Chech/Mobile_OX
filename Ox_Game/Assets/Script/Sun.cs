using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

    public float Speed = 0;
    public GameObject Player;

    void Update()
    {
        transform.RotateAround(Player.transform.position, Vector3.forward, Speed);     
    }
}
