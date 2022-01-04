using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform firstSaveSpot;

    Transform currSaveSpot;
    Player player;

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
    }

    public void ResetLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetPlayer()
    {
        player.transform.position = currSaveSpot.position;
    }
}
