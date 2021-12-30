using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform firstSaveSpot;
    [SerializeField] LayerMask groundLayers;

    Transform currSaveSpot;
    Player player;
    CharacterController cc;
    bool grounded;
    [SerializeField] float groundedRadius = .28f, groundedOffset = -.14f;

    public Transform CurrentSaveSpot { get { return currSaveSpot; } set { currSaveSpot = value; } }
   
    static GameManager instance;
    public static GameManager Instance {
        get {
            if (!instance) {
                instance = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
            }
            return instance;
        }
    }

    private void Start() {
        player = Player.Instance;
        CurrentSaveSpot = firstSaveSpot;
        cc = player.GetComponent<CharacterController>();
    }

    private void Update() {
        //GroundedCheck();
    }

    private void GroundedCheck() {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z);
        grounded = Physics.CheckSphere(spherePosition, groundedRadius, groundLayers, QueryTriggerInteraction.Ignore);

        if (!grounded) {
            Debug.Log("oopsie i died");
            cc.enabled = false;
            player.transform.position = currSaveSpot.transform.position;
            cc.enabled = true;
        }
    }

    public void ResetLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
