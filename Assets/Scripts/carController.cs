using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    public int maxHealth = 100; //100 not 10
    public float timeInvincible = 1f;

    public int currentHealth;
    public int catchUp = 5;
    public float catchUpRepairCooldown = .25f;
    public float defRepairCooldown = 1;
    public int health { get { return currentHealth; } }
    public int maxHealthReached;
    bool tryMakeInvincible;
    bool isInvincible;
    float invincibleTimer;
    public UICarHealth hp;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 10;
        maxHealthReached = 10;
        tryMakeInvincible = false;
        isInvincible = false;
        hp.UpdateValues(currentHealth);
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
        if(tryMakeInvincible && ! isInvincible)
        {
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        tryMakeInvincible = false;
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            tryMakeInvincible = true;
        }


        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        if (currentHealth > maxHealthReached) { maxHealthReached = currentHealth; }
        if (currentHealth < maxHealthReached - catchUp) { player.repairCooldown = catchUpRepairCooldown; Debug.Log("gah"); }
        else { player.repairCooldown = defRepairCooldown; }
        hp.UpdateValues(currentHealth);
    }
}