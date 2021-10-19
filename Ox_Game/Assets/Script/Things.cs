using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Things : MonoBehaviour
{
    private float Lift_Time = 5;
    public float Speed = 0;

    Rigidbody My_rigidbody;

    void Start()
    {
        My_rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Lift_Time -= Time.deltaTime;
        if (Lift_Time <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        Vector3 move = new Vector3(0, 0, 1);
        move.z = transform.position.z - Speed * Time.deltaTime;
        My_rigidbody.MovePosition(move);
    }
    private void OnTriggerEnter(Collider other)
    {
       /* if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }*/
    }


}
