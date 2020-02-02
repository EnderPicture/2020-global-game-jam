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
    public float repairCooldown;
    float attackTimer;
    float repairTimer;

    float lastAttacked;

    public OneWayGroundCheck oneWayGroundCheck;

    public Collider[] attackHitboxes;
    public GroundCheck groundCheck;
    public SpriteRenderer spriteR;
    public Animator animator;

    public AudioSource walk;
    public AudioSource attack;

    public int attackState = 1;

    float lastJump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastJump = Time.realtimeSinceStartup;
        lastAttacked = Time.realtimeSinceStartup;
    }
    void Update()
    {
        // Attack Timing
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;
        if (repairTimer > 0)
            repairTimer -= Time.deltaTime;
        // Key Activate Attack
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))  //changed key cuz j is dumb
        {
            LaunchAttack(attackHitboxes[0]);
        }
    } // Update 
    void FixedUpdate()
    {
    // Movement 
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
    
        Vector2 direction = new Vector2(0, 0);
        Vector3 velocity = rb.velocity;

    // Key Activate Move Player
        if (horizontal > 0) {
            transform.localScale = new Vector3(1, 1, 1);
            direction.x = 1;
            if( !walk.isPlaying )
                walk.Play();
        } else if (horizontal < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
            direction.x = -1;
            if (!walk.isPlaying)
                walk.Play();
        } else {
            walk.Stop();
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
        float bufferTime = .3f;
        float timeSinceAttack = Time.realtimeSinceStartup - lastAttacked;
        Debug.Log(timeSinceAttack);
        if (attackState == 1)
        {
            float animationTime = .06f / .11f;
            if (timeSinceAttack < animationTime - bufferTime)
            {
            }
            else if (timeSinceAttack > animationTime + bufferTime)
            {
                attackState = 1;
            }
        }
        if (attackState == 2)
        {
            float animationTime = .06f / .07f;
            if (timeSinceAttack < animationTime - bufferTime)
            {
            }
            else if (timeSinceAttack > animationTime + bufferTime)
            {
                attackState = 1;
            }
        }
        if (attackState == 3)
        {
            float animationTime = .06f / .22f;
            if (timeSinceAttack < animationTime - bufferTime)
            {
            }
            else if (timeSinceAttack > animationTime + bufferTime)
            {
                attackState = 1;
            }
        }
        objCollider = attackHitboxes[0];
        attack.Play();
        animator.Play("PlayerAttack"+ attackState);
        attackState += 1;
        lastAttacked = Time.realtimeSinceStartup;

        if (attackState > 3)
        {
            attackState = 1;
        }

        if (attackState == 3)
        {
            objCollider = attackHitboxes[1];
        }


        // maybe make it so cooldown only animation
        if (attackTimer <= 0)
        {
            Collider[] enemyColliderInfo = Physics.OverlapBox(objCollider.bounds.center, objCollider.bounds.extents, objCollider.transform.rotation, LayerMask.GetMask("Enemy"));
            if (enemyColliderInfo.Length != 0) 
            {
                for (int e = 0; e < enemyColliderInfo.Length; e++)
                {
                    enemy Enemy = enemyColliderInfo[e].gameObject.GetComponent<enemy>();
                    if (Enemy != null) { Enemy.damage(1, -transform.localScale.x); }
                }
                attackTimer = attackCooldown;
            }
            else if(repairTimer <= 0)
            {
                Collider[] car = Physics.OverlapBox(objCollider.bounds.center, objCollider.bounds.extents, objCollider.transform.rotation, LayerMask.GetMask("car"));
                if (car.Length != 0)
                {
                    Debug.Log ("UICarHealth?");
                    carController thecar = car[0].gameObject.GetComponent<carController>();
                    thecar.ChangeHealth(1);
                    Debug.Log (thecar.currentHealth);
                    repairTimer = repairCooldown;
                }
            }
        }
    } // Launch Attack
} // Class Player
