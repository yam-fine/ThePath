using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    Vector3 distFromTarget;

    // Start is called before the first frame update
    void Start()
    {
        distFromTarget = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + distFromTarget;
    }
}
