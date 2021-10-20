using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Instance : MonoBehaviour
{
    private float Load_Timer = 0;
    private float Car_Timer = 0;
    public Vector3 move = Vector3.right;
    public GameObject[] Prefabs_Loads;
    public GameObject[] Prefabs_Things;
    [SerializeField]
    public int Prefab_num;
    [SerializeField]
    public Vector3 New_Prefab_V3 = Vector3.zero;
    [SerializeField]
    public GameObject Car;

    private void Awake()
    {
        Prefabs_Loads = Resources.LoadAll("Load").Cast<GameObject>().ToArray();
        Prefabs_Things = Resources.LoadAll("Things").Cast<GameObject>().ToArray();
    }

    void Update()
    {
        Timer_for_Load(Manager.Instance_Load_Time);
        Timer_for_Car(Manager.Instance_Car_Time);
    }

    void Timer_for_Load(float Instance_Time)
    {
        Load_Timer -= Time.deltaTime;
        if (Load_Timer <= 0)
        {
            Load_Timer = Instance_Time;
            Instance_Random_Loads();
        }
    }//地圖生成計時
    void Timer_for_Car(float Instance_Time)
    {
        Car_Timer -= Time.deltaTime;
        if (Car_Timer <= 0)
        {
            Car_Timer = Instance_Time;
            Instance_Random_Cars();
        }
    }//障礙物生成計時

    void Instance_Random_Cars()
    {
        int Random_int = Random.Range(0, Prefabs_Things.Length);
        int Random_X = Random.Range(-1, 2);
        switch (Random_X)
        {
            case (-1):
                Car = Instantiate(Prefabs_Things[Random_int],
                                            new Vector3(Random_X, transform.position.y, -transform.position.z),
                                            Quaternion.Euler(0, 180, 0));
                Car.tag = "Turn_Car";
                Car.AddComponent<Things>();
                Car.GetComponent<Things>().Speed = Random.Range(-20, -25);
                break;
            case (0):
                return;
            case (1):
                Car = Instantiate(Prefabs_Things[Random_int],
                                             new Vector3(Random_X, transform.position.y, transform.position.z),
                                             Quaternion.identity);
                Car.AddComponent<Things>();
                Car.GetComponent<Things>().Speed = Random.Range(8, 10);
                break;
        }
        /* if ( Random_X == 0)
         {
             
         }
         else
         {
             GameObject New_Prefabs = Instantiate(Prefabs_Things[Random_int],
                                              new Vector3(Random_X, transform.position.y, transform.position.z),
                                              Quaternion.identity);
             New_Prefabs.AddComponent<Things>();
             New_Prefabs.GetComponent<Things>().Speed = Random.Range(8, 10);
         }*/
    }//生成障礙物
    void Instance_Random_Loads()
    {
        int Random_int = Random.Range(0, Prefabs_Loads.Length);
        GameObject Next_Prefabs = Instantiate(Prefabs_Loads[Random_int], new Vector3(0, 0, New_Prefab_V3.z + 10f), Quaternion.identity);
        Next_Prefabs.AddComponent<Things>();
        New_Prefab_V3 = Next_Prefabs.transform.position;
    }//生成地圖
}
