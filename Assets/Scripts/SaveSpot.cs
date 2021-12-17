using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSpot : MonoBehaviour
{
    GameManager gm;

    void Start()
    {
        gm = GameManager.Instance;
    }

    private void OnTriggerEnter(Collider other) {
        gm.CurrentSaveSpot = transform;
    }
}
