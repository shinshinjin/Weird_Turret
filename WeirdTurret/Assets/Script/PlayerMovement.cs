using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;

    private Rigidbody _rigid;
    private PlayerController _playerController;

    void Start()
    { 
        _rigid = GetComponent<Rigidbody>();
        _playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        float Speed_X = _playerController.X * Speed;
        float Speed_Z = _playerController.Z * Speed;
        _rigid.velocity = new Vector3(Speed_X, 0f, Speed_Z);
    }
}
