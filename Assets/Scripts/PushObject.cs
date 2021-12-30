using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour {
    
    [SerializeField] float forceScale;

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb != null) {
            rb.AddForce(transform.forward * forceScale, ForceMode.Impulse);
        }
    }
}
