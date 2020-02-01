using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayGroundCheck : MonoBehaviour
{
    public Collider playerCollider;

    void OnTriggerStay(Collider other)
    {   
        Physics.IgnoreCollision(playerCollider, other, true);
    }
    void OnTriggerExit(Collider other)
    {
    }

    public void onExitTriggerExit(Collider other) {
        Physics.IgnoreCollision(playerCollider, other, false);
    }
}
