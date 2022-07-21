using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killzone : MonoBehaviour {
    public int respawnScene = 0;

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            //TODO: change later to add support for checkpoints..
            SceneManager.LoadScene (respawnScene);
        }
    }
}