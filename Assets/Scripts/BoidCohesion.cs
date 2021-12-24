using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Boids))]
public class BoidCohesion : MonoBehaviour
{
    Boids myBoid;
    List<Boids> boids;

    // Start is called before the first frame update
    void Start()
    {
        myBoid = GetComponent<Boids>();
        boids = new List<Boids>();
        foreach (Boids b in FindObjectsOfType<Boids>())
            if (b != myBoid)
                boids.Add(b);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
