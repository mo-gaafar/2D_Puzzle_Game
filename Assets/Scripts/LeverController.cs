using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverController : MonoBehaviour {

    [SerializeField] private bool isOn = false;
    [SerializeField] private SpriteRenderer redSprite;
    [SerializeField] private SpriteRenderer greenSprite;
    public UnityEvent leverOn;
    public UnityEvent leverOff;

    // Start is called before the first frame update
    void Start () {
        LeverOff ();
    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            ToggleLever ();
        }
    }

    void LeverOn () {
        //turn green alpha to 1
        Color tempColor = greenSprite.color;
        tempColor.a = 1f;
        greenSprite.color = tempColor;
        //turn red alpha to 0
        tempColor = redSprite.color;
        tempColor.a = 0f;
        redSprite.color = tempColor;

        leverOn.Invoke ();

    }

    void LeverOff () {
        //turn green alpha to 0
        Color tempColor = greenSprite.color;
        tempColor.a = 0f;
        greenSprite.color = tempColor;
        //turn red alpha to 1
        tempColor = redSprite.color;
        tempColor.a = 1f;
        redSprite.color = tempColor;

        leverOff.Invoke ();
    }

    void ToggleLever () {
        if (isOn) {
            LeverOff ();
            isOn = false;
        } else {
            LeverOn ();
            isOn = true;
        }
    }
}