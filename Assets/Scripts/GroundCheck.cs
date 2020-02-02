using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    Collider ground = null;
    public Collider trigger;
    void OnTriggerEnter(Collider other)
    {
        ground = other;
        Debug.Log("onground");
    }
    void OnTriggerExit(Collider other)
    {
        ground = null;
        Debug.Log("offground");
    }
    public bool isOnGround() {
        return ground != null;
    }
    public Collider getGround() {
        return ground;
    }
}
