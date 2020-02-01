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

    float lastJump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastJump = Time.realtimeSinceStartup;
    }
    void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

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
            if (direction.y > 0)
            {
                rb.AddForce(0, boostJump, 0, ForceMode.Impulse);
                lastJump = Time.realtimeSinceStartup;
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
