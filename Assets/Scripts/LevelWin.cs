using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelWin : MonoBehaviour {

    public UnityEvent OnLevelWin;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            // UnityEventManager.TriggerEvent("LevelWin");
            OnLevelWin.Invoke ();
        }
    }
}