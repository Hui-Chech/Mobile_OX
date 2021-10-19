using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Control : MonoBehaviour
{
    [SerializeField]
    private float Speed = 0;
    [SerializeField]
    private float Force = 0;

    //  public bool Jumping = false;

    public delegate void Is_Jumping();
    Is_Jumping Jumping;
    Rigidbody Character_rigidbody;
    Animator animator;

    private void OnEnable()
    {
        Event_Send.Touch += Jump;
    }
    void Start()
    {
        Character_rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Jumping += Jump;

    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {
        Vector3 move = new Vector3(1, 0, 0);
        move.x = transform.position.x - Speed * Time.deltaTime;
        Character_rigidbody.MovePosition(move);
    }
    public void Jump()
    {
        animator.SetTrigger("Jump");
        Character_rigidbody.AddForce(Vector3.up * 9.8f * Force);
        Event_Send.Touch -= Jump;
        Jumping -= Jump;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Jumping == null)
        {

            Event_Send.Touch += Jump;
            Jumping += Jump;
        }
    }

}
