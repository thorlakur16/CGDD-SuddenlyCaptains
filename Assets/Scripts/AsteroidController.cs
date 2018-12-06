using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    public Animator animator;
    public ShipHandler theShip;
    public float rotation;
    public float speed;
    public Transform target;
    private float showForAsteroid = 40;

    private bool hit = false;
	// Use this for initialization
	void Start () {
        theShip = FindObjectOfType<ShipHandler>();
        target = transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hit)
        {
            transform.Translate(0, -Time.deltaTime * theShip.speed, 0);
            transform.rotation = Quaternion.identity;
        }
        else
        {
            transform.Rotate(0, 0, Time.deltaTime * rotation);

            var distToAst = CalculateDistanceToTarget(); //Distance from ship to asteroid

            //Check how close the ship is to asteroid
            //if(distToAst.magnitude < showForAsteroid)
            //{
            //    transform.GetChild(0).gameObject.SetActive(true);

            //    RotateArrowToFollowTarget(distToAst);
            //} else if(transform.position.y > theShip.transform.position.y)
            //{
            //    Destroy(gameObject);
            //} else
            //{
            //    transform.GetChild(0).gameObject.SetActive(false);
            //}
        }
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //play animation explode
        animator.SetTrigger("Explode");
        hit = true;
        Destroy(gameObject, 0.4f);
        //
    }

    //For arrow indicator
    private Vector3 CalculateDistanceToTarget()
    {
        return transform.position - target.position;
    }

    //For arrow indicator
    private void RotateArrowToFollowTarget(Vector3 direction)
    {
        var angle = Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
