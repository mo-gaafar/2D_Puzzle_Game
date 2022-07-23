using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour {

    // AudioSource sound;

    public bool isPressed = false;
    public UnityEvent onPress;
    public UnityEvent onRelease;

    SpriteRenderer buttonHead;
    public SpringJoint2D spring;

    private Transform transform;
    private Vector2 initialLocation;
    private float displacementThreshold = 0.03f;

    // Start is called before the first frame update
    void Start () {
        // sound = GetComponent<AudioSource> ();
        buttonHead = GetComponent<SpriteRenderer> ();
        spring = GetComponent<SpringJoint2D> ();
        isPressed = false;

        transform = GetComponent<Transform> ();
        initialLocation = new Vector2 (transform.position.x, transform.position.y);

    }

    void Update () {

        if ((initialLocation.y - transform.position.y) > displacementThreshold) {
            ButtonPressed ();
        } else {
            ButtonReleased ();
        }
        // Debug.Log ("Distance: " + spring.distance);

    }

    void ButtonPressed () {
        isPressed = true;
        onPress.Invoke ();

        buttonHead.color = Color.green;
    }

    void ButtonReleased () {
        isPressed = false;
        onRelease.Invoke ();

        buttonHead.color = Color.red;
    }

}