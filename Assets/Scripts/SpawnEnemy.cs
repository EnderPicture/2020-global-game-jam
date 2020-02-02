using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    float timer = 0;

    public Transform car;

    public Spawner spawner1;
    public Spawner spawner2;
    public Spawner spawner3;
    public Spawner spawner4;

    // Start is called before the first frame update
    void Start()
    {
        spawner1.car = car;
        spawner2.car = car;
        spawner3.car = car;
        spawner4.car = car;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1.5)
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

    public void spawnXPatternObject(bool s1, bool s2, bool s3, bool s4, GameObject go) {
        if (s1)
        spawner1.spawnGameObject(go);
        if (s2)
        spawner2.spawnGameObject(go);
        if (s3)
        spawner3.spawnGameObject(go);
        if (s4)
        spawner4.spawnGameObject(go);
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
