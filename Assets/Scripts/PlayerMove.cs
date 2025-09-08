using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float minSpeed;
    public float maxSpeed;

    public float acceleration;

    float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = minSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            currentPos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentPos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentPos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentPos.x += speed * Time.deltaTime;
        }
        if (transform.position != currentPos)
        {
            if (speed < maxSpeed)
            {
                speed += acceleration;
            }
        }
        else
        {
            speed = minSpeed;
        }
        transform.position = currentPos;
    }
}
