﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TimedEvents : MonoBehaviour
{
    public carController Car;
    public GameObject Enemy;
    public GameObject RedEnemy;
    public GameObject FastEnemy;
    public SpawnEnemy spawnEnemy;
    bool Event0 = false;
    bool Event1 = false;
    bool Event2 = false;
    bool Event3 = false;
    bool Event4 = false;
    bool Flying = false;

    // Update is called once per frame
    void Update()
    {
        if (Car.currentHealth >= 20 && Event0 == false) Spawn0();
        if (Car.currentHealth >= 25 && Event1 == false) Spawn1();
        if (Car.currentHealth >= 40 && Event2 == false) Spawn2();
        if (Car.currentHealth >= 50 && Event3 == false) Spawn3();
        if (Car.currentHealth >= 55) Flying = true;
        if (Car.currentHealth >= 75 && Event4 == false) Spawn4();

        void Spawn0 ()
        {
                int numEnemies = 50;
        for (int i = 0; i < numEnemies; i++)
            {
            spawnEnemy.spawnXPatternObject(true,false,true,false, Enemy);
            Event0 = true;
            }
        }
        void Spawn1 ()
        {
            spawnEnemy.spawnXPatternObject(true,false,true,false, RedEnemy);
            Event1 = true;
        }

        void Spawn2 ()
        {
            spawnEnemy.spawnXPatternObject(true,true,true,true, FastEnemy);
            Event2 = true;
        }

        void Spawn3 ()
        {
        spawnEnemy.spawnXPatternObject(true,false,true,false, RedEnemy);
        spawnEnemy.spawnXPatternObject(false,true,false,true, FastEnemy);
            Event3 = true;
        }
        void Spawn4 ()
        {
        //spawnEnemy.spawnXPatternObject(true,false,true,false, RedEnemy);
        //spawnEnemy.spawnXPatternObject(false,true,false,true, FastEnemy);
            //Event4 = true;
        }
    }
}
