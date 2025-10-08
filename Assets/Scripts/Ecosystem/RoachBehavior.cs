using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class RoachBehavior : InsectBehavior
{
    //our individual kinds of bugs all inherit from the InsectBehavior class
    //this class contains all the variables and functions shared by insects

    [SerializeField]
    float speed;

    //enum is like a custom variable type
    //we're using it to make states for our roach's behavior
    enum RoachStates
    {
        eating,
        inLight,
        dying,
        idling
    }

    //current state
    RoachStates state = RoachStates.idling;
    bool inLight = false;

    void Update()
    {
        //switch statement for our statement
        //cleaner way of checking the same condition
        switch (state)
        {
            case RoachStates.idling: //if we're in the idle state
                RunIdle(); //run idle code
                break;
            case RoachStates.eating: //if we're in the eating state
                RunEat(); //run eating code
                break;
            case RoachStates.inLight:
                RunLight();
                break;
            case RoachStates.dying:
                break;
            default:
                break;
        }
    }

    void RunIdle()
    {
        if (inLight) FindNewDir();
        StepNeeds(); //increment stat timers
        if (hungerVal <= 0)
        { //if our roach is hunger
            target = null; //remove whatever target we were moving towards
            GetComponent<SpriteRenderer>().flipY = false;
            state = RoachStates.eating; //switch the state to eating
        }
    }

    void RunEat()
    {
        if (target == null)
        { //if we do not have a target to move to
            FindAllFood(); //find all food objs in the scene
            target = FindNearest(allFood); //find the closest food obj and set our target to it
            startPos = transform.position; //set our starting pos to our current pos
            lerpTime = 0; //reset our lerp progress
        }
        else
        {
            transform.position = Move(); //move to food
            if (touchingObj != null)
            { //if we're touching a game object
                if (touchingObj.tag == "food")
                {  //and that object is tagged as food
                    hungerVal = 5; //reset our hunger
                    Destroy(touchingObj); //destroy that food
                    touchingObj = null; //empty our food tracking variable
                    target = null; //empty our movement target
                    state = RoachStates.idling; //switch the state to idle
                }
            }
        }
    }

    void RunLight()
    {
        transform.position += transform.up * Time.deltaTime * speed;
        if (!inLight) state = RoachStates.idling;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("light")) touchingObj = col.gameObject; //if we touch something, set the var to whatever that thing is
        if (!inLight && col.CompareTag("light")) inLight = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == touchingObj) touchingObj = null; //AND that thing is being tracked, clear the touching tracking var
        if (inLight && col.CompareTag("light")) inLight = false;
    }

    void FindNewDir()
    {
        float randX = Random.Range(-1, 1);
        float randY = Random.Range(-1, 1);
        Vector3 randDir = new Vector3(randX, randY);
        randDir.Normalize();
        transform.up = randDir;
        GetComponent<SpriteRenderer>().flipY = true;
        state = RoachStates.inLight;
    }

}
