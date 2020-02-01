using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float burstSpeed = 0;

    [Range(0.0f, 1.0f)]
    public float acc = 0;
    public float maxSpeed = 0;

    [Range(0.0f, 1.0f)]
    public float drag = 0;

    public float jumpStrength;

    int lastXDirection;
    int lastYDirection;

    float xSpeed = 0;
    float ySpeed = 0;
    Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        int xDirection = 0;
        int yDirection = 0;

        if (vertical > 0)
        {
            yDirection = 1;
        }
        else if (vertical < 0)
        {
            yDirection = -1;
        }
        

        if (horizontal > 0)
        {
            xDirection = 1;
        }
        else if (horizontal < 0)
        {
            xDirection = -1;
        }


        if (yDirection != lastYDirection && yDirection != 0)
        {
            rigidbody.AddForce(0, jumpStrength, 0, ForceMode.VelocityChange);
            // ySpeed = burstSpeed * yDirection;
        }
        else if (xDirection != 0)
        {
            // ySpeed += maxSpeed * acc * yDirection;
        }
        else
        {
            // ySpeed -= ySpeed * drag;
            // ySpeed -= gravity;
        }
        lastYDirection = yDirection;
        

        if (xDirection != lastXDirection && xDirection != 0)
        {
            xSpeed = burstSpeed * xDirection;
        }
        else if (xDirection != 0)
        {
            xSpeed += maxSpeed * acc * xDirection;
        }
        else
        {
            xSpeed -= xSpeed * drag;
        }
        lastXDirection = xDirection;
        xSpeed = Mathf.Clamp(xSpeed, -maxSpeed, maxSpeed);
        // ySpeed = Mathf.Clamp(ySpeed, -maxSpeed, maxSpeed);


        Debug.Log(xSpeed);

        Vector3 velocity = rigidbody.velocity;
        velocity.x = xSpeed;
        // velocity.y = ySpeed;
        rigidbody.velocity = velocity;

    }
}
