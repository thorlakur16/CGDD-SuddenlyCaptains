using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour {

    public Transform target;
    public GameObject theShip;
    public float hide;
    private float showForAsteroid = 40;
    private Animator anim;
    private ArrayList asteroids;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {

        if(tag == "LandingPlatform")
        {
            var distanceToPlatform = CalculateDistanceToTarget();

            if (distanceToPlatform.magnitude < hide)
            {
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
            else
            {
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(true);
                }

                RotateArrowToFollowTarget(distanceToPlatform);
            }
        }

        //Loop through the list and calculate distance for all.
        //If distance is smaller than showForAsteroid then Instasiate an arrow with that object as a target

        //foreach(GameObject asteroid in asteroids)
        //{
        //    var distToAst = CalculateDistanceToTarget();

        //    if(distToAst.magnitude < showForAsteroid)
        //    {
        //        var arrow = Instantiate(gameObject);
        //    }
        //}


        
        if (tag == "Asteroid")
        {
            ShipHandler ship = FindObjectOfType<ShipHandler>();
            target = ship.middleOfShip;
            var distanceToAsteroid = CalculateDistanceToTarget();
            //Check how close the ship is to asteroid
            if (distanceToAsteroid.magnitude < showForAsteroid)
            {
                transform.GetChild(0).gameObject.SetActive(true);

                RotateArrowToFollowTarget(distanceToAsteroid);
            } else
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
            if (distanceToAsteroid.magnitude < hide)
            {
                Destroy(gameObject);
            }
            
            //Debug.Log(distanceToAsteroid.y - 5);
        }



        //if (direction.magnitude < hide)
        //{
            
        //} else
        //{
        //    foreach (Transform child in transform)
        //    {
        //        if(tag == "Asteroid")
        //        {
        //            child.gameObject.SetActive(false);
        //        }
        //        if(tag == "Asteroid" && direction.magnitude < showForAsteroid)
        //        {
        //            child.gameObject.SetActive(true);
        //            Instantiate(gameObject);
        //            //target =

        //            var list = FindObjectOfType<AsteroidCreator>().allAsteroids;
        //            //child.gameObject.GetComponent<Animator>().SetTrigger("setActive");
        //            //anim.SetTrigger("setActive");
        //        }
        //        if (tag == "LandingPlatform")
        //        {
        //            child.gameObject.SetActive(true);
        //        }
        //    }

            
        //}
        
    }

    private Vector3 CalculateDistanceToTarget()
    {
        return target.position - theShip.transform.position;
    }

    private void RotateArrowToFollowTarget(Vector3 direction)
    {
        var angle = Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
