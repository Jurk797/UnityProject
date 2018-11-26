using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationToTarget : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform rotationPart;
    
    public void Rotate(Transform target)
    {
        var heading = target.transform.position - rotationPart.position;
        var angle = Mathf.Atan2(heading.y, heading.x) * Mathf.Rad2Deg - 180;

        rotationPart.rotation = Quaternion.Lerp(rotationPart.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * speed) ;
    }
}
