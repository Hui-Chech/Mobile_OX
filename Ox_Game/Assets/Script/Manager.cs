using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField]
    public static float Character_Speed = 3;
    [SerializeField]
    public static float Car_Speed = 0;
    [SerializeField]
    public static float Instance_Car_Time=1f;
    [SerializeField]
    public static float Instance_Load_Time = 0.5f;
    [SerializeField]
    public static float Instance_Thins = 0.7f;
    [SerializeField]
    private static float Score = 0;
    [SerializeField]
    private static float ScoreSpeed = 3;
    [SerializeField]
    private Text Score_Text;
    private void Start()
    {
        InvokeRepeating("Speed_Plus", 2.0f, 2.0f);
    }

    private void Update()
    {
        Score += Time.deltaTime * ScoreSpeed;
        Score_Text.text = ((int)Score).ToString();
    }
    void Speed_Plus()
    {
        Manager.Character_Speed += 0.5f;
        Manager.ScoreSpeed += 0.5f;
    }
}
