using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Instance : MonoBehaviour
{
    public float Instance_Time = 0;
    public float Timer = 0;
    public Vector3 move = Vector3.right;
    public GameObject[] Prefabs;

    private void Awake()
    {
        Prefabs = Resources.LoadAll("Things").Cast<GameObject>().ToArray();
    }
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Timer = Instance_Time;
            Instance_Random_Things();
        }
    }

    private void Instance_Random_Things()
    {
        int Random_int = Random.Range(0, Prefabs.Length);
        var Random_Z = Random.Range(-3f, 3f);
        GameObject New_Prefabs = Instantiate(Prefabs[Random_int], new Vector3(transform.position.x,transform.position.y,
                                                                              Random_Z),
                                                                              Quaternion.identity);
        if (New_Prefabs.tag == "Tree")
        {
            New_Prefabs.GetComponent<BoxCollider>().isTrigger = false;
        }
        New_Prefabs.AddComponent<Things>();
        New_Prefabs.GetComponent<Things>().Speed = Random.Range(8, 10);


    }
}
