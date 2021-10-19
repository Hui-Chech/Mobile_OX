﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Things : MonoBehaviour
{
    public float Speed = 0;

    Rigidbody My_rigidbody;


    void Start()
    {
        My_rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (tag != "Load")
        {
            Vector3 move = Vector3.forward;
            move.z = transform.position.z - Speed * Time.deltaTime;
            My_rigidbody.MovePosition(move);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (tag == "Car" && other.gameObject.tag == "Player")
        {
            Debug.Log("小雞撞到了");
        }
        if (other.gameObject.tag == "Delect" && tag != "Turn_Car")
        {
            Destroy(this.gameObject);
        }
        if (tag == "Turn_Car" && other.gameObject.tag == "Turn_Delect")
        {
            Destroy(this.gameObject);
        }

    }
    private void OnCollisionEnter(Collision Other)
    {
        if (tag == "Car" && Other.gameObject.tag == "Player")
        {
            Debug.Log("小雞撞到了");
        }
    }


}
