using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] Canvas defaultCanvas, onTriggerCanvas;

    private void OnTriggerEnter(Collider other) {
        defaultCanvas.enabled = false;
        onTriggerCanvas.enabled = true;
        //AUDIO
    }

    private void OnTriggerExit(Collider other) {
        defaultCanvas.enabled = true;
        onTriggerCanvas.enabled = false;
    }
}
