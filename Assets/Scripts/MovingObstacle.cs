using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] List<Transform> goTo;
    [SerializeField] float speed;

    int currTarget = 0;
    float epsilon = .1f;
    Vector3 epsilonVec;

    private void Start() {
        epsilonVec = new Vector3(epsilon, epsilon, epsilon);
    }

    void Update()
    {
        //if (transform.position + epsilonVec >= goTo[currTarget].position)
        //transform.position = Mathf.Lerp(transform.position, goTo[currTarget].position, Time.deltaTime * speed);
    }
}
