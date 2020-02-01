using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayExit : MonoBehaviour
{
    public OneWayGroundCheck check;
    void OnTriggerExit(Collider other)
    {
        check.onExitTriggerExit(other);
    }
}
