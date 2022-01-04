using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingChange : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private LayerMask envMask;
    [SerializeField] private LayerMask obsMask;
    private bool change;
    
    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (change)
            {
                cam.cullingMask = envMask;
                change = false;
            }
            else
            {
                cam.cullingMask = obsMask;
                change = true;
            }
        }
    }
}
