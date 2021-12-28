using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Material onMaterial;
    [SerializeField] private Material offMaterial;
    [SerializeField] private PatternCube cube;
    private Renderer rd;
    private bool on = true;

    private void Start()
    {
        rd = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (on)
        {
            rd.material = offMaterial;
            cube.StopCube();
            on = false;
        }
        else
        {
            rd.material = onMaterial;
            cube.StartCube();
            on = true;
        }
    }
}
