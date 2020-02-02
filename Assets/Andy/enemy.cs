using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float heath = 1;
    public float noise = .1f;

    Rigidbody rb;
    Vector2 lastDirection;

    public float boostX;
    public float accX;
    public float maxSpeedX;
    public float dampX;

    public float boostJump;
    public float accJump;
    public float accJumpDuration;

    public float vertical = 0;
    public float horizontal = 1;

    public OneWayGroundCheck oneWayGroundCheck;

    public Collider[] attackHitboxes;
    public GroundCheck groundCheck;

    float lastJump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastJump = Time.realtimeSinceStartup;

        maxSpeedX += Random.Range(-noise, noise);
    }
    void FixedUpdate()
    {
        movement();
        if (Input.GetKeyDown(KeyCode.J))
        {
            LaunchAttack(attackHitboxes[0]);
        }
    }

    void movement()
    {


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
            rb.AddForce(accX * direction.x * (maxSpeedX - Mathf.Abs(velocity.x)), 0, 0);
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

    void LaunchAttack(Collider col)
    {
        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider c in cols)
        {
            Debug.Log(c.name);
        }

    }
}
