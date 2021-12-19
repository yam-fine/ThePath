using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] string nextLevelName;

    // MAKE SURE ONLY PLAYER CAN TRIGGER THIS
    private void OnTriggerEnter(Collider other) {
        SceneManager.LoadScene(nextLevelName);
    }
}
