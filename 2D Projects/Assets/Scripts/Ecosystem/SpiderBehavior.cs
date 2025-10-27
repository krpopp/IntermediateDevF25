using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.AI;

public class SpiderBehavior : InsectBehavior
{

    //enum is like a custom variable type
    //we're using it to make states for our spider's behavior
    enum SpiderStates
    {
        eating,
        showering,
        dying,
        idling
    }

    //current state
    SpiderStates state = SpiderStates.idling;

    public NavMeshAgent agent;

    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        hungerVal = hungerStart;
        hungerTime = hungerStep; //reset our hunger timer
    }
    
    void Update()
    {
        //hungerText.text = hungerVal.ToString();
        //switch statement for our statement
        //cleaner way of checking the same condition
        switch (state)
        {
            case SpiderStates.idling: //if we're in the idle state
                RunIdle(); //run idle code
                break;
            case SpiderStates.eating: //if we're in the eating state
                RunEat(); //run eating code
                break;
            case SpiderStates.showering:
                break;
            case SpiderStates.dying:
                break;
            default:
                break;
        }
    }

    void RunIdle()
    {
        if (target == null)
        { //if we do not have a target to move to
            target = GameObject.Find("Web").transform; //set our target to a web in the scene;
            agent.SetDestination(target.position);
            //startPos = transform.position; //set our starting pos to our current pos
            //lerpTime = 0; //reset our lerp progress
        }
        else
        {
            //transform.position = Move(); //move to that position
        }
        StepNeeds(); //increment stat timers
        if (hungerVal <= 0)
        { //if our spider is hunger
            target = null; //remove whatever target we were moving towards
            state = SpiderStates.eating; //switch the state to eating
        }
    }

    void RunEat() {
        if(target == null){ //if we do not have a target to move to
            FindAllFood(); //find all food objs in the scene
            target = FindNearest(allFood); //find the closest food obj and set our target to it
            startPos = transform.position; //set our starting pos to our current pos
            lerpTime = 0; //reset our lerp progress
        } else {
            transform.position = Move(); //move to food
            if(touchingObj != null){ //if we're touching a game object
                if(touchingObj.tag == "food"){  //and that object is tagged as food
                    allFood.Remove(touchingObj); //remove that food from the food list
                    hungerVal = 5; //reset our hunger
                    Destroy(touchingObj); //destroy that food
                    touchingObj = null; //empty our food tracking variable
                    target = null; //empty our movement target
                    state = SpiderStates.idling; //switch the state to idle
                }
            }
        }
    }

}
