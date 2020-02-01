using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    bool onGround = false;
    void OnTriggerEnter(Collider other)
    {
        onGround = true;
    }
    void OnTriggerExit(Collider other)
    {
        onGround = false;
    }
    public bool isOnGround() {
        return onGround;
    }
}
