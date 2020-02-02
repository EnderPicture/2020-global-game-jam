using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    public int maxHealth = 100; //100 not 10
    public float timeInvincible = 1.0f;

    public int currentHealth;
    public int health { get { return currentHealth; } }

    bool isInvincible;
    float invincibleTimer;
    public UICarHealth hp;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }


        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);


        if (amount == 1)
            hp.SetValue(currentHealth - 1, true);
        else
            hp.SetValue(currentHealth, false);

    }
}