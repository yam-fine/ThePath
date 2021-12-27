using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour {
    
    [SerializeField] float forceScale;

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb != null) {
            Vector3 forceDir = hit.gameObject.transform.position - transform.position;
            forceDir.y = 0;
            forceDir.Normalize();
            rb.AddForceAtPosition(forceDir * forceScale, transform.position, ForceMode.Impulse);
        }
    }
}
