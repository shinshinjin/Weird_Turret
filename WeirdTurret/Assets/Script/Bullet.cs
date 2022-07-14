using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float ShootSpeed = 5f;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(0f, 0f, ShootSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.SetActive(false);
        }
    }
}
