using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform firstSaveSpot;
    [SerializeField] int mapHeight = -10;

    Transform currSaveSpot;
    Player player;
    CharacterController cc;

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
        if (player.transform.position.y < mapHeight) {
            cc.enabled = false;
            player.transform.position = currSaveSpot.transform.position;
            cc.enabled = true;
        }
    }

    public void ResetLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
