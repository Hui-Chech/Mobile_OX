using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger_Touch : MonoBehaviour
{
    public float Dash_Time = 3;
    public float Dash_Speed = 5;
    public float Timer = 0;
    public float Speed = 0;

    public bool Is_Dash = false;

    Rigidbody My_rigidbody;
    private void OnEnable()
    {
        Event_Send.Touch += Dash;
        Timer = Dash_Time;
    }
    private void OnDisable()
    {
        Event_Send.Touch -= Dash;
    }
    private void Start()
    {
        My_rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Useing_With_Finger();
        Dash_Timer();
    }
    private void FixedUpdate()
    {
        Vector3 move = new Vector3(1, 0, 0);
        move.z = transform.position.z + Speed * Time.deltaTime;
        My_rigidbody.MovePosition(move);
    }

    void Useing_With_Finger()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            var Direction = Input.GetTouch(0).deltaPosition;
            transform.Translate(Direction.x * Time.deltaTime * 0.1f, 0, 0);
        }
    }
    void Dash()
    {
        if (!Is_Dash)
        {
            Is_Dash = true;
        }
    }
    void Dash_Timer()
    {
        if (Is_Dash)
        {
            if (Timer > 0)
            {
                Timer -= Time.deltaTime;
                My_rigidbody.velocity = transform.forward * Dash_Time * Dash_Speed;
            }
            else if (Timer <= 0)
            {
                Is_Dash = false;
                Timer = Dash_Time;
            }
        }
        else
        {
            return;
        }
    }
}
