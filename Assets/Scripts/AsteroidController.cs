using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    public Animator animator;
    public ShipHandler theShip;
    public Transform target;
    public float rotation;
    public float speed;
    private float showForAsteroid = 40;

    public float hide;

    private bool hit = false;
	// Use this for initialization
	void Start () {
        theShip = FindObjectOfType<ShipHandler>();
        gameObject.AddComponent<Rigidbody2D>();
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
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
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //play animation explode
        animator.SetTrigger("Explode");
        if(coll.name == "theShip")
        {
            hit = true;
            theShip.ShipIsHit();
        }
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
