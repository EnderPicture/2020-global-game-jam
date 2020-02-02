using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    Vector2 lastDirection;

    public float boostX;
    public float accX;
    public float maxSpeedX;
    public float dampX;

    public float boostJump;
    public float accJump;
    public float accJumpDuration;
    public float maxSpeedY;

    public float attackCooldown;
    public float attackTimer;

    public OneWayGroundCheck oneWayGroundCheck;

    public Collider[] attackHitboxes;
    public GroundCheck groundCheck;
    public SpriteRenderer spriteR;
    public Animator animator;

    float lastJump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastJump = Time.realtimeSinceStartup;
    }
    void Update()
    {
        // Attack Timing
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;
    } // Update 
    void FixedUpdate()
    {
    // Key Activate Attack
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) )  //changed key cuz j is dumb
        {
            LaunchAttack(attackHitboxes[0]);
        }

    // Movement 
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
    
        Vector2 direction = new Vector2(0, 0);
        Vector3 velocity = rb.velocity;

    // Key Activate Move Player
        if (horizontal > 0) {
            transform.localScale = new Vector3(-1, 1, 1);
            direction.x = 1;
        } else if (horizontal < 0) {
            transform.localScale = new Vector3(1, 1, 1);
            direction.x = -1;
        }

        if (vertical > 0)
            direction.y = 1;
        else if (vertical < 0)
            direction.y = -1;

    // Movement Feeling
        if (direction.x != lastDirection.x && direction.x != 0) {
            velocity.x = boostX * direction.x;
        } else if (direction.x != 0) {
            rb.AddForce(accX * direction.x * Mathf.Clamp(maxSpeedX - (velocity.x * direction.x), 0, maxSpeedX), 0, 0);
        } else {
            rb.AddForce(-velocity.x * dampX, 0, 0);
        }

    // Up Down Movement
        if (direction.y != lastDirection.y && direction.y != 0)
        {
            // Go Up
            if (direction.y > 0 && groundCheck.isOnGround())
            {
                rb.AddForce(0, boostJump, 0, ForceMode.Impulse);
                lastJump = Time.realtimeSinceStartup;
            }
            // Go Down
            if (direction.y < 0 && groundCheck.isOnGround())
                oneWayGroundCheck.goDown();
        }
        else if (direction.y != 0)
        {
            if (direction.y > 0)
            {
                float timeUsage = Helper.Map(Time.realtimeSinceStartup - lastJump, 0, accJumpDuration, 1, 0);
                timeUsage = Mathf.Clamp(timeUsage, 0, 1);
                rb.AddForce(0, accJump * timeUsage, 0);
            }
        }

        rb.velocity = velocity;
        lastDirection = direction;
    } // FixedUpdate

    void LaunchAttack(Collider objCollider)
    {
        // maybe make it so cooldown only animation
        if (attackTimer <= 0)
        {
            Collider[] enemyColliderInfo = Physics.OverlapBox(objCollider.bounds.center, objCollider.bounds.extents, objCollider.transform.rotation, LayerMask.GetMask("Enemy"));
            if (enemyColliderInfo.Length != 0) 
            {
                for (int e = 0; e < enemyColliderInfo.Length; e++)
                {
                    enemy Enemy = enemyColliderInfo[e].gameObject.GetComponent<enemy>();
                    if (Enemy != null) { Enemy.damage(1,-(int)lastDirection.x); }
                }
                attackTimer = attackCooldown;
            }
            else
            {
                Collider[] car = Physics.OverlapBox(objCollider.bounds.center, objCollider.bounds.extents, objCollider.transform.rotation, LayerMask.GetMask("car"));
                if (car.Length != 0)
                {
                    Debug.Log ("UICarHealth?");
                    carController thecar = car[0].gameObject.GetComponent<carController>();
                    thecar.ChangeHealth(1);
                    Debug.Log (thecar.currentHealth);
                    attackTimer = attackCooldown;
                }
            }
        }
    } // Launch Attack
} // Class Player
