using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayGroundCheck : MonoBehaviour
{
    public Collider playerCollider;
    public GroundCheck groundCheck;

    void OnTriggerStay(Collider other)
    {
        Physics.IgnoreCollision(playerCollider, other, true);
        Physics.IgnoreCollision(groundCheck.trigger, other, true);
    }

    public void onExitTriggerExit(Collider other)
    {
        Physics.IgnoreCollision(playerCollider, other, false);
        Physics.IgnoreCollision(groundCheck.trigger, other, false);
    }

    public void goDown()
    {
        Debug.Log("godown");
        Collider ground = groundCheck.getGround();
        if (ground != null && ground.tag == "OneWay")
        {
            Physics.IgnoreCollision(playerCollider, ground, true);
        }
    }
}
