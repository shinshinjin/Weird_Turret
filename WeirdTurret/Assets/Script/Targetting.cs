using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetting : MonoBehaviour
{
    public bool isTarget { get; private set; }
    public GameObject Target { get; private set; }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isTarget = true;
            Target = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        isTarget = false;
        Target = null;
    }
}
