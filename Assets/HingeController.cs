using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeController : MonoBehaviour {
    // Start is called before the first frame update
    public void DestroyHinge () {
        Destroy (GetComponent<HingeJoint2D> ());
    }
}