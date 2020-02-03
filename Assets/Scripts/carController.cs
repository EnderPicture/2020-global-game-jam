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
    public Sprite[] carSprites;
    public SpriteRenderer spriteRenderer;

    public AudioSource carHit;
    public AudioSource carRepair;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 24;
        maxHealthReached = 10;
        tryMakeInvincible = false;
        isInvincible = false;
        hp.UpdateValues(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth >= 90){
                spriteRenderer.sprite = carSprites[1];}
        else if (currentHealth >= 80){
                spriteRenderer.sprite = carSprites[2];}
        else if (currentHealth >= 70){
                spriteRenderer.sprite = carSprites[3];}
        else if (currentHealth >= 60){
                spriteRenderer.sprite = carSprites[4];}
        else if (currentHealth >= 50){
                spriteRenderer.sprite = carSprites[5];}
        else if (currentHealth >= 40){
                spriteRenderer.sprite = carSprites[6];}
        else if (currentHealth >= 30){
                spriteRenderer.sprite = carSprites[7];}
        else if (currentHealth >= 20){
                spriteRenderer.sprite = carSprites[8];}
        else if (currentHealth >= 10){
                spriteRenderer.sprite = carSprites[9];}                                 
        
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        if(tryMakeInvincible && ! isInvincible)
        {
            carHit.Play();
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
        } else
        {
            carRepair.Play();
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        if (currentHealth > maxHealthReached) { maxHealthReached = currentHealth; }
        if (currentHealth < maxHealthReached - catchUp) { 
            player.repairCooldown = catchUpRepairCooldown; 
            Debug.Log("gah");
        }
        else { player.repairCooldown = defRepairCooldown; }
        hp.UpdateValues(currentHealth);
    }
}