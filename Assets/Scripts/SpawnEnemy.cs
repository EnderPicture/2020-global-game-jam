using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    float timer = 0;

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
        //float extraspawn;
        //extraspawn = Random.range(0,3);
        //GameObject = Instantiate(Enemy, transform.position, transform.rotation);
    }
    void Spawn1()
    {
        //GameObject = Instantiate(Enemy, transform.position, transform.rotation);
    }
    void Spawn2()
    {
        //GameObject = Instantiate(Enemy, transform.position, transform.rotation);
    }
    void Spawn3()
    {
        // GameObject = Instantiate(Enemy, transform.position, transform.rotation);
    }
}
