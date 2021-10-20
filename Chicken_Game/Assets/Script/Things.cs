using System.Collections;
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
        Car_Move();
    }
    void Car_Move()
    {
        if (tag != "Load")
        {
            Vector3 move = Vector3.forward;
            move.z = transform.position.z - Speed * Time.deltaTime;
            My_rigidbody.MovePosition(move);
        }
    }//車子前進_*FixedUpdate*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Delect" && tag != "Turn_Car")
        {
            Destroy(this.gameObject);
        }
        if (tag == "Turn_Car" && other.gameObject.tag == "Turn_Delect")
        {
            Destroy(this.gameObject);
        }

    }//雙向道車輛銷毀


}
