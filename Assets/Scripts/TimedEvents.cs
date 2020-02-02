using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TimedEvents : MonoBehaviour
{
    public int CarHP = 0;
    public GameObject RedEnemy;
    bool Event1 = false;
    bool Event2 = false;
    bool Event3 = false;

    // Update is called once per frame
    void Update()
    {
        CarHP += 1;

        if (CarHP >= 25 && Event1 == false) Spawn1();
        if (CarHP >= 50 && Event2 == false) Spawn2();
        if (CarHP >= 75 && Event3 == false) Spawn3();

        void Spawn1 ()
        {
            //GameObject = Instantiate(RedEnemy, transform.position, transform.rotation);
            //Create RedEnemy at SpawnLocation1;  
            //Create RedEnemy at SpawnLocation2;
            Event1 = true;
        }

        void Spawn2 ()
        {
            //Create RedEnemy at SpawnLocation1;
            //Create RedEnemy at SpawnLocation3;
            //Create RedEnemy at SpawnLocation4;
            Event2 = true;
        }

        void Spawn3 ()
        {
            //Create RedEnemy at SpawnLocation1;
            // Create RedEnemy at SpawnLocation1;
            //Create RedEnemy at SpawnLocation2;
            //Create RedEnemy at SpawnLocation2;
            // Create RedEnemy at SpawnLocation3;
            // Create RedEnemy at SpawnLocation4;
            Event3 = true;
        }
    }
}
