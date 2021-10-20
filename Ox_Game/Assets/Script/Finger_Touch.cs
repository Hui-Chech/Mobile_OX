using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger_Touch : MonoBehaviour
{
    public float Dash_Time = 3;
    public float Dash_Speed = 5;
    public float Timer = 0;

    public bool Is_Dash = false;

    Rigidbody My_rigidbody;
    Animator My_animator;

    private void OnEnable()
    {
        Event_Manager.Touch_Event += Dash;
        Timer = Dash_Time;
    }//放入事件(Dash)
    private void OnDisable()
    {
        Event_Manager.Touch_Event -= Dash;
    }//收回事件(Dash)
    private void Start()
    {
        My_rigidbody = GetComponent<Rigidbody>();
        My_animator = GetComponent<Animator>();
    }
    void Update()
    {
        Dash_Timer();//衝刺計時
    }
    private void FixedUpdate()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            var Direction = Input.GetTouch(0).deltaPosition;
            transform.Translate(Direction.x * Time.deltaTime * 0.3f, 0, Manager.Character_Speed * Time.deltaTime);
        }//觸控水平移動
        else
        {
            Vector3 move = new Vector3(transform.position.x, 0, 0);
            move.z = transform.position.z + Manager.Character_Speed * Time.deltaTime;
            My_rigidbody.MovePosition(move);
        }//自行前進
    }//玩家觸控水平移動  角色自行前進
    void Dash()
    {
        if (!Is_Dash)
        {
            Is_Dash = true;
            My_animator.SetTrigger("Jump");
        }
    }//衝刺
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
    }//衝刺計時
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Car" || collision.transform.tag == "Turn_Car")
        {
            Event_Manager.Instance.Game_over();
        }
    }//執行事件(Game_Over)
}
