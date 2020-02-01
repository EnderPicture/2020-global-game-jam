using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float burstSpeed = 0;
    public float acc = 0;
    public float maxSpeed = 0;

    [Range(0.0f, 1.0f)]
    public float drag = 0;


    int lastDirection;

    float speed = 0;
    Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        int direction = 0;


        if (horizontal > 0)
        {
            direction = 1;
        }
        else if (horizontal < 0)
        {
            direction = -1;
        }


        if (direction != lastDirection && direction != 0)
        {
            speed = burstSpeed * direction;
        }
        else if (direction != 0)
        {
            speed += acc * direction;
        }
        else
        {
            speed -= speed * drag;
        }

        lastDirection = direction;

        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
        Vector3 velocity = rigidbody.velocity;
        velocity.x = speed;
        rigidbody.velocity = velocity;

    }
}
