// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Events;

// public class ButtonController : MonoBehaviour {

//     // public GameObject button;
//     public UnityEvent onPress;
//     public UnityEvent onRelease;
//     GameObject presser;
//     // AudioSource sound;
//     bool isPressed = false;

//     // Start is called before the first frame update
//     void Start () {
//         // sound = GetComponent<AudioSource> ();
//         isPressed = false;
//     }

//     private void OnTriggerEnter (Collider other) {
//         if (isPressed) {
//             // button.transform.localPosition = new Vector3 (0, 0, 0);
//             presser == other.gameObject;
//             // sound.Play ();
//             isPressed = true;
//         }
//     }

//     private void OnTriggerExit (Collider other) {
//         if (other == presser) {
//             // button.transform.localPosition = new Vector3 (0, 0, 0);
//             onRelease.Invoke ();
//             isPressed = false;
//         }
//     }
// }