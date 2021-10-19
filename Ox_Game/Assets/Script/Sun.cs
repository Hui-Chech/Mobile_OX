using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float Speed = 0;
    public GameObject Player;

    public GameObject[] Night_Light;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Player.transform.position, Vector3.forward, Speed);
        
    }
}
