using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float health = 1;
    public float noise = .1f;

    public Transform car; // Why?

    Rigidbody rb;
    Vector2 lastDirection;

    public int attack = -3;
    public float boostX;
    public float accX;
    public float maxSpeedX;
    public float dampX;

    public float boostJump;
    public float accJump;
    public float accJumpDuration;

    public float vertical = 0;
    public float horizontal = 1;

    public float deathTime = 1/4;

    public OneWayGroundCheck oneWayGroundCheck;

    public Collider[] attackHitboxes;
    public GroundCheck groundCheck;

    float lastJump;
    bool isDead = false;

    public UICarHealth theuicarhealth;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastJump = Time.realtimeSinceStartup;
        maxSpeedX += Random.Range(-noise, noise);
    }

    void FixedUpdate()
    {
        movement();
    }

    void movement()
    {
        if(!isDead){ 
            // go to car 
            float distanceToCar = car.position.x - transform.position.x;
            if (distanceToCar > 0)
                horizontal = 1; // right 
            else
                horizontal = -1; // left

            Vector2 direction = new Vector2(0, 0);
            Vector3 velocity = rb.velocity;

            if (horizontal > 0)
            {
                direction.x = 1;
            }
            else if (horizontal < 0)
            {
                direction.x = -1;
            }
            if (vertical > 0)
            {
                direction.y = 1;
            }
            else if (vertical < 0)
            {
                direction.y = -1;
            }


            if (direction.x != lastDirection.x && direction.x != 0)
            {
                velocity.x = boostX * direction.x;
            }
            else if (direction.x != 0)
            {
                rb.AddForce(accX * direction.x * Mathf.Clamp(maxSpeedX - (velocity.x * direction.x), 0, maxSpeedX), 0, 0);
            }
            else
            {
                rb.AddForce(-velocity.x * dampX, 0, 0);
            }


            if (direction.y != lastDirection.y && direction.y != 0)
            {
                if (direction.y > 0 && groundCheck.isOnGround())
                {
                    rb.AddForce(0, boostJump, 0, ForceMode.Impulse);
                    lastJump = Time.realtimeSinceStartup;
                }
                if (direction.y < 0 && groundCheck.isOnGround())
                {
                    oneWayGroundCheck.goDown();
                }
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
        }
    }

    public void damage(int damage, int direction)
    {
        health -= damage;
        if (health <= 0)
        {
            isDead = true;
            Destroy(gameObject, deathTime);
            animator.Play("GatorDeath");
            int horizontal = Random.Range(0,7) * 100 + 700 * direction;
            int vertical = Random.Range(0, 5) * 100 + 900;
            Vector3 force = new Vector3(horizontal, vertical, 0);
            rb.AddForce(force);
        }
        
    }

    private void OnCollisionStay(Collision other)
    {
        if (!isDead && other.gameObject.tag == "car")
        {
            other.gameObject.GetComponent<carController>().ChangeHealth(attack);
        }
    }

}
