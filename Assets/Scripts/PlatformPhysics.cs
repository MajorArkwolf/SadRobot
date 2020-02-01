using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPhysics : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
        other.transform.SetParent(transform);

    }

    void OnTriggerExit2D(Collider2D other) {
        other.transform.SetParent(null);
    }
}