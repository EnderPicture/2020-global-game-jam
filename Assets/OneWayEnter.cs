using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayEnter : MonoBehaviour
{
    Collider enteredCollider = null;
    void OnTriggerEnter(Collider other)
    {
        enteredCollider = other;
    }
    void OnTriggerExit(Collider other)
    {
        enteredCollider = null;
    }
    Collider getCollider() {
        return enteredCollider;
    }
}
