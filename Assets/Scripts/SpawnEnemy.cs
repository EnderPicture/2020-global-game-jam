using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    float timer = 0;

    public Spawner spawner1;
    public Spawner spawner2;
    public Spawner spawner3;
    public Spawner spawner4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            float randomspawn;
            randomspawn = Random.Range(0, 3);

            if (randomspawn == 0)
            {
                Spawn0();
            }
            if (randomspawn == 1)
            {
                Spawn1();
            }
            if (randomspawn == 2)
            {
                Spawn2();
            }
            if (randomspawn == 3)
            {
                Spawn3();
            }


            timer = 0;
        }




    }
    void Spawn0()
    {
        // spawner1.mode = 0;
        // spawner1.amount = 1;
        spawner1.spawn();
    }
    void Spawn1()
    {
        spawner2.spawn();
    }
    void Spawn2()
    {
        spawner3.spawn();
    }
    void Spawn3()
    {
        spawner4.spawn();
    }
}
