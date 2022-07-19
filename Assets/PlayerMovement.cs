using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    private float angleOld = 0f;
    private float angleNew = 0f;

    Vector2 mousePos = new Vector2 ();
    public Camera cam;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform particleGun;

    // Update is called once per frame
    void Update () {

        horizontal = Input.GetAxis ("Horizontal");

        mousePos = cam.ScreenToWorldPoint (Input.mousePosition);

        //if jump is pressed then set y axis velocity to jump power
        if (Input.GetButtonDown ("Jump") && IsGrounded ()) {
            rb.velocity = new Vector2 (rb.velocity.x, jumpingPower);
        }

        // on release, decay y axis velocity to 0
        if (Input.GetButtonUp ("Jump") && rb.velocity.y > 0) {
            rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y / 2);
        }

        if (Input.GetMouseButtonDown (0)) {
            ShootParticles (true);
        }
        if (Input.GetMouseButtonUp (0)) {
            ShootParticles (false);
        }

        Flip (); //keep checking for flip
    }

    private void FixedUpdate () {
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);

        Vector2 lookDir = mousePos - rb.position;
        angleNew = Mathf.Atan2 (lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        float angle = angleOld - angleNew;
        angleOld = angleNew;

        particleGun.Rotate (0, angle, 0);

    }

    private void ShootParticles (bool enable) {
        if (enable)
            particleGun.gameObject.SetActive (true);
        else
            particleGun.gameObject.SetActive (false);
    }

    // check if player is on the ground
    private bool IsGrounded () {
        //create invisibile circle at feet and check for overlap 
        return Physics2D.OverlapCircle (groundCheck.position, 0.1f, groundLayer);
    }

    //flip player if he is facing the wrong way 
    private void Flip () {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) {
            isFacingRight = !isFacingRight; //Toggle variable
            Vector3 theScale = transform.localScale; //Get the scale of the object
            theScale.x *= -1; //Flip the object
            transform.localScale = theScale;
        }
    }
}