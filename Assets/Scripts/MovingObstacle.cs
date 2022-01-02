using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] List<Transform> goTo;
    [SerializeField] float speed;

    int currTarget = 0;
    float epsilon = .1f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, goTo[currTarget].position, Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, goTo[currTarget].position) <= epsilon) {
            currTarget++;
            if (currTarget == goTo.Count)
                currTarget = 0;
        }
    }
}
