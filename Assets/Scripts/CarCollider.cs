using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollider : MonoBehaviour
{
    private int enemyhits = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        enemyhits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("enemy in range:" + (enemyhits));
    }

    void OnTriggerStay(Collider other)
    {
        enemyhits += 1;
    }

}
