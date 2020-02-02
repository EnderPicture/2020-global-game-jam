﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform tl;
    public Transform br;

    public static int RAND = 0;
    public int mode = RAND;
    public int amount = 10;

    public GameObject[] enemies;

    public void spawn() {
        if (mode == RAND) {
            for (int c = 0; c < amount; c++) {
                int rand = Random.Range(0, enemies.Length);
                GameObject newEnemy = GameObject.Instantiate(enemies[rand]);
            }
        }
    }
}
