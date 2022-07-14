using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WeirdTurret : MonoBehaviour
{
    public float ShootCoolTime = 0.1f;
    public GameObject BulletPrefab;
    public Transform FirePos;
    public float angleRange = 60f;
    public float distance = 5f;
    public bool isCollision = false;
    public float DotValue = 0f;
    public Transform target;

    private Targetting _targetting;
    private float _elapsedTime;

    Color _blue = new Color(0f, 0f, 1f, 0.2f);
    Color _red = new Color(1f, 0f, 0f, 0.2f);

    Vector3 Direction;

    void Awake()
    {
        _targetting = GetComponentInChildren<Targetting>();
    }

    void Update()
    {
        if (_targetting.isTarget)
        {
            TargetIn();
        }
        else
        {
            TargetOut();
        }


    }

    void TargetOut()
    {
        _elapsedTime = ShootCoolTime;
    }

    void TargetIn()
    {
        _elapsedTime += Time.deltaTime;

        DotValue = Mathf.Cos(Mathf.Deg2Rad * (angleRange / 2));
        Direction = target.position - transform.position;

        if (Direction.magnitude < distance)
        {
            if (Vector3.Dot(Direction.normalized, transform.forward) > DotValue)
            {
                isCollision = true;
                transform.LookAt(_targetting.Target.transform);
            }
            else
            {
                isCollision = false;
            }
        }

        else
        {
            isCollision = false;
        }

        if (_elapsedTime >= ShootCoolTime && isCollision == true)
        {
            _elapsedTime = 0f;
            Instantiate(BulletPrefab, FirePos.position, FirePos.rotation);
        }
    }

    private void OnDrawGizmos()
    {
        Handles.color = isCollision ? _red : _blue;
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, angleRange / 2, distance);
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -angleRange / 2, distance);
    }
}
