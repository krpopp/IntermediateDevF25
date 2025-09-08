using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float minSpeed;
    public float maxSpeed;

    public float acceleration;

    float speed;

    bool goLeft = true;
    bool goRight = true;
    bool goTop = true;
    bool goBottom = true;

    AudioSource myCDPlayer;
    //AudioSource mySource;

    public AudioClip dingCD;
    //public AudioClip dingClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = minSpeed;
        myCDPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        if (Input.GetKey(KeyCode.W) && goTop)
        {
            currentPos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && goBottom)
        {
            currentPos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && goLeft)
        {
            currentPos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && goRight)
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("trigger hit");
        if (collision.CompareTag("left"))
        {
            goLeft = false;
            Debug.Log("hit left border");
        }
        if (collision.CompareTag("right"))
        {
            goRight = false;
        }
        if (collision.CompareTag("top"))
        {
            goTop = false;
        }
        if (collision.CompareTag("bottom"))
        {
            goBottom = false;
        }
        if (collision.CompareTag("flower"))
        {
            if (collision.gameObject.GetComponent<BloomFlower>().didDing == false)
            {
                myCDPlayer.PlayOneShot(dingCD);
                collision.gameObject.GetComponent<Animator>().SetBool("doBloom", true);
                collision.gameObject.GetComponent<BloomFlower>().didDing = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("left"))
        {
            goLeft = true;
        }
        if (collision.CompareTag("right"))
        {
            goRight = true;
        }
        if (collision.CompareTag("top"))
        {
            goTop = true;
        }
        if (collision.CompareTag("bottom"))
        {
            goBottom = true;
        }
    }

}
