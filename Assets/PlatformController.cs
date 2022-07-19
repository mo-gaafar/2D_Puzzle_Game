using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    public bool isActive;

    Collider2D collider;

    // Start is called before the first frame update
    void Start () {
        collider = GetComponent<Collider2D> ();
    }

    // Update is called once per frame
    void Update () {

    }

    public void ActivatePlatform () {
        if (!isActive)
            SetState (true);
    }
    public void DeactivatePlatform () {
        if (isActive)
            SetState (false);
    }

    public void TogglePlatform () {
        if (isActive) {
            DeactivatePlatform ();
        } else {
            ActivatePlatform ();
        }
    }

    void SetState (bool open) {
        isActive = open;
        collider.isTrigger = open;
    }
}