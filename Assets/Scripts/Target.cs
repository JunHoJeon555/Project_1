using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            transform.position = new Vector3(Random.Range(0,50f),0, Random.Range(0, 50f));
        }
    }
}
