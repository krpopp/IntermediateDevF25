using UnityEngine;
using System.Collections.Generic;

public class InsectBehavior : MonoBehaviour
{

    [SerializeField]
    public float lerpTimeMax; //appr. how long we want a lerp to last

    [SerializeField]
    public float hungerStep; //max time we want to wait to deincrement hunger

    public Transform target = null; //current spot we're moving towards
    public Vector3 startPos = Vector3.zero; //current spot we're moving from

    //count of current lerp progress
    public float lerpTime;

    [SerializeField]
    AnimationCurve moveCurve;

    //timer that'll count down for hunger
    public float hungerTime;
    [SerializeField]
    public float hungerStart;
    //hunger stat
    public float hungerVal;

    //list for food currently in the scene
    public List<GameObject> allFood = new List<GameObject>();

    //holds which game object the spider has touched
    public GameObject touchingObj;


    public void StepNeeds(){
        hungerTime -= Time.deltaTime; //deincrement the hunger timer
        if(hungerTime <= 0){ //if the hunger timer gets to 0
            hungerVal--; //decrease our hunger stat
            hungerTime = hungerStep; //reset the hunger timer
        }
    }

    public void FindAllFood(){
        allFood.AddRange(GameObject.FindGameObjectsWithTag("food")); //find all objs tagged food and put them in a list
    }

    public Transform FindNearest(List<GameObject> objsToFind){
        float minDist = Mathf.Infinity; //setting the min dist to a big number
        Transform nearest = null; //tracks the obj closest to us
        for(int i = 0; i < objsToFind.Count; i++){ //loop through the objects we're checking
            float dist = Vector3.Distance(transform.position, objsToFind[i].transform.position); //check the dist b/t the spider and the current obj
            if(dist < minDist){ //if the dist is less than our currently tracked min dist
                minDist = dist; //set the min dist to the new dist
                nearest = objsToFind[i].transform; //set the nearest obj var to this obj
            }
        }
        return nearest; //return the closest obj
    }

    public Vector3 Move(){
        lerpTime += Time.deltaTime; //increase progress by delta time (time b/t frames)
        float percent = moveCurve.Evaluate(lerpTime/lerpTimeMax); //from progress on curve
        Vector3 newPos = Vector3.LerpUnclamped(startPos, target.position, percent); //find current lerped position
        Vector3 dir = (startPos - target.position).normalized;
        transform.up = dir;
        return newPos; //return the new position
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col != null) touchingObj = col.gameObject; //if we touch something, set the var to whatever that thing is
    }

    void OnTriggerExit2D(Collider2D col){
        if(col != null) { //if we stop touching something 
            if(col.gameObject == touchingObj) touchingObj = null; //AND that thing is being tracked, clear the touching tracking var
        }
    }
}
