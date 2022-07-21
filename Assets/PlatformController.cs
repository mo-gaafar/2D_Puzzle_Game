using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    public bool isActive = false;

    Collider2D collider;
    SpriteRenderer sprite;

    public int collisionHealth;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start () {
        collider = GetComponent<Collider2D> ();
        sprite = GetComponent<SpriteRenderer> ();
        collisionHealth = 50;
        DeactivatePlatform ();
    }

    // Update is called once per frame
    void Update () {
        if (healthText)
            healthText.text = collisionHealth.ToString ();
        else
            Debug.Log ("Null HealthText");
    }

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
    private void OnParticleCollision (GameObject other) {
        collisionHealth--;

        if (collisionHealth <= 0) {

            TogglePlatform ();
            collisionHealth = 50;
        }
        Debug.Log ("collisionHealth: " + collisionHealth);
        Debug.Log ("Layer: " + gameObject.layer);
    }
}