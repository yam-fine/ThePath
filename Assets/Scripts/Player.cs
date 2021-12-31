using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController cc;
    private bool touchingLava;
    static Player instance;
    [SerializeField] LayerMask groundLayers;
    [SerializeField] float groundedRadius = .28f, groundedOffset = -.14f;
    private void Start() {
        cc = GetComponent<CharacterController>();
    }
    private void LateUpdate()
    {
        GroundedCheck();
    }

    public static Player Instance {
        get {
            if (!instance) {
                instance = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            }
            return instance;
        }
    }
    
    private void GroundedCheck() {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z);
        touchingLava = Physics.CheckSphere(spherePosition, groundedRadius, groundLayers);
        if (touchingLava) {
            Debug.Log("oopsie i died");
            cc.enabled = false;
            gameObject.transform.position = GameManager.Instance.CurrentSaveSpot.transform.position;
            cc.enabled = true;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z), groundedRadius);

    }
}
