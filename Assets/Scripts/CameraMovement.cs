using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float boundX = 0.15f;
    [SerializeField] private float boundZDown = 0.05f;
    [SerializeField] private float boundZUp = 0.05f;
    [SerializeField] private float speed = 2f;
    private Vector3 here;
    private bool follow = false;
    [SerializeField] private float zOffset = 3f;
    [SerializeField] private float xOffset = 3f;
    private Vector3 distFromTarget;

    private void Start()
    {
        distFromTarget = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var currPos = transform.position;
        var pos = transform.position;
        float deltaX = target.position.x - currPos.x - xOffset;
        float deltaZ = target.position.z - currPos.z - zOffset;
        if (follow)
        {
            pos = Vector3.MoveTowards(transform.position, here, Time.deltaTime * speed);
        }
        if (deltaX > boundX || deltaX < -boundX)
        {
            here = target.position + distFromTarget;
            follow = true;
        }
        else if (deltaZ > boundZUp || deltaZ < -boundZDown)
        {
            here = target.position + distFromTarget;
            follow = true;
        }
        else
        {
            follow = false;
        }
        

        transform.position = pos;
        
    }
}
