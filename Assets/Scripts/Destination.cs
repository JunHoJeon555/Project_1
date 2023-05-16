using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    Transform[] targets;

    int index = 0;

    //Next => 도착했을 때 실행하는 함수. Next일 때 도착한 값을 변경하고, 
    //new Vector3(Random.Range(0, 100f), Random.Range(0, 100f), Random.Range(0, 100f));

    public Transform CurrentTarget => targets[index];

    private void Awake()
    {
        targets = new Transform[transform.childCount];
        for(int i = 0; i < targets.Length; i++)
        {
            targets[i] = transform.GetChild(i);
        }
    }
    private void Start()
    {
        targets[0].position = new Vector3 (Random.Range(0, 30f), 0/*Random.Range(0, 30f)*/, Random.Range(0, 30f));
    }

    public Transform NextTarget()
    {
        index++;
        index %= targets.Length;
        //targets[index].position = new Vector3(Random.Range(0, 30f), 0f/*Random.Range(0, 30f)*/, Random.Range(0, 30f));
        return targets[index];
    }

}
