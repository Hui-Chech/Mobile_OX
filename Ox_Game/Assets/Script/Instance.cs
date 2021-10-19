using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Instance : MonoBehaviour
{
    public float Instance_Time = 0;
    public float Timer = 0;
    public Vector3 move = Vector3.right;
    public GameObject[] Prefabs_Loads;
    public GameObject[] Prefabs_Things;
    [SerializeField]
    public int Prefab_num;
    [SerializeField]
    public Vector3 New_Prefab_V3 = Vector3.zero;

    private void Awake()
    {
        Prefabs_Loads = Resources.LoadAll("Load").Cast<GameObject>().ToArray();
        Prefabs_Things = Resources.LoadAll("Things").Cast<GameObject>().ToArray();
    }
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Timer = Instance_Time;
            Instance_Random_Loads();
        }
    }

    private void Instance_Random_Things()
    {
        int Random_int = Random.Range(0, Prefabs_Things.Length);
        var Random_Z = Random.Range(-3f, 3f);
        GameObject New_Prefabs = Instantiate(Prefabs_Things[Random_int], new Vector3(transform.position.x, transform.position.y,
                                                                              Random_Z),
                                                                              Quaternion.identity);
        if (New_Prefabs.tag == "Tree")
        {
            New_Prefabs.GetComponent<BoxCollider>().isTrigger = false;
        }
        New_Prefabs.AddComponent<Things>();
        New_Prefabs.GetComponent<Things>().Speed = Random.Range(8, 10);
    }
    private void Instance_Random_Loads()
    {
        int Random_int = Random.Range(0, Prefabs_Loads.Length);
        GameObject Next_Prefabs = Instantiate(Prefabs_Loads[Random_int], new Vector3(0, 0, New_Prefab_V3.z + 10f), Quaternion.identity);
        New_Prefab_V3 = Next_Prefabs.transform.position;
        Instance_Random_Things();
    }
}
