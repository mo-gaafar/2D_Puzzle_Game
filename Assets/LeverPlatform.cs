using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverPlatform : MonoBehaviour {

    // public UnityEvent leverOn;
    // public UnityEvent leverOff;

    public bool isActive;

    // Collider2D collider;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start () {
        // leverOn.AddListener (ActivatePlatform);
        // leverOff.AddListener (DeactivatePlatform);
        sprite = GetComponent<SpriteRenderer> ();
    }

    // Update is called once per frame
    void Update () {

    }

    //TODO: object oriented can be useful here.... 

    public void ActivatePlatform () {
        if (isActive)
            SetState (false);
    }
    public void DeactivatePlatform () {
        if (!isActive)
            SetState (true);
    }

    public void TogglePlatform () {
        if (!isActive) {
            DeactivatePlatform ();
        } else {
            ActivatePlatform ();
        }
    }

    void SetState (bool open) {

        isActive = open;
        if (open) {

            Color tempColor = sprite.color;
            tempColor.a = 0.5f;
            sprite.color = tempColor;
            gameObject.layer = LayerMask.NameToLayer ("DisabledPlatform");
            Debug.Log ("Platform disabled");
        } else {
            sprite.color = new Color (0f, 0.5f, 1f, 1f);
            gameObject.layer = LayerMask.NameToLayer ("Ground");
            Debug.Log ("Platform activated");
        }
    }

}