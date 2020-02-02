using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    Collider ground = null;
    public Collider trigger;
    void OnTriggerStay(Collider other)
    {
        ground = other;
    }
    void OnTriggerExit(Collider other)
    {
        ground = null;
    }
    public bool isOnGround() {
        return ground != null;
    }
    public Collider getGround() {
        return ground;
    }
}
