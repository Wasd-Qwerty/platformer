using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void FixedUpdate()
    {
        var position = _target.position;
        position.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, position, 0.18f);
    }
}
