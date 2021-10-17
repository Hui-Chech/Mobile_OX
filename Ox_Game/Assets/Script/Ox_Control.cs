using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ox_Control : MonoBehaviour
{
    [SerializeField]
    private float Speed = 0;

    Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 move = new Vector3(1, 0, 0);
        move.x = transform.position.x - Speed * Time.deltaTime;
        rigidbody.MovePosition(move);
    }
}
