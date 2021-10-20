using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private static float Last_Score,Score = 0;
    [SerializeField]
    private static float ScoreSpeed = 3;
    [SerializeField]
    public static float Sun_Speed = 0.3f;

    [SerializeField]
    private Text Now_Score_Text;
    [SerializeField]
    private Text End_Score_Text,Last_Score_Text;
    [SerializeField]
    private GameObject Gameover_Image;

    bool Is_Gameover;

    private void OnEnable()
    {
        Event_Manager.Gameover_Event += Game_Over;
    }
    private void OnDisable()
    {
        Event_Manager.Gameover_Event -= Game_Over;
    }
    private void Awake()
    {
        Gameover_Image.SetActive(false);
        Last_Score = Score;
        Score = 0;
    }
    private void Start()
    {
        InvokeRepeating("Speed_Plus", 2.0f, 2.0f);
    }
    private void Update()
    {
        Score_Plus();
    }
    void Speed_Plus()
    {
        Manager.Character_Speed += 0.5f;
        Manager.ScoreSpeed += 0.5f;
    }//定時更新玩家速度_2.0f/次_(InvokeRepeating)_*(Start)*
    void Score_Plus()
    {
        if (!Is_Gameover)
        {
            Score += Time.deltaTime * ScoreSpeed;
            Now_Score_Text.text = ((int)Score).ToString();
        }
    }//分數計算_*(Update)*
    public void Game_Over()
    {
        Is_Gameover = true;
        Gameover_Image.SetActive(true);//顯示遊戲結束畫面
        Last_Score_Text.text = ((int)Last_Score).ToString();//顯示先前分數
        End_Score_Text.text = Now_Score_Text.text;//結算當前分數
        Event_Manager.Gameover_Event -= Game_Over;//退訂事件_(遊戲結束)
    }//遊戲結束_顯示結算畫面並退訂事件(Event_Manager_Gameover)
    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }//重製遊戲_重新讀取場景
}
