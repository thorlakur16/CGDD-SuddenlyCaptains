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
    public AudioClip explodeSound;
    AudioSource audioSource;

    public float hide;

    private bool hit = false;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
        audioSource = GetComponent<AudioSource>();
    }
    private void Awake()
    {
        theShip = FindObjectOfType<ShipHandler>();
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
        
        if (transform.position.y > theShip.transform.position.y+20f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //play animation explode
        animator.SetTrigger("Explode");

        if(coll.name != "asteroid-use")
        {
            transform.GetComponent<CircleCollider2D>().isTrigger = false;
            //transform.gameObject.AddComponent<CircleCollider2D>();
            hit = true;
            theShip.ShipIsHit();
            audioSource.PlayOneShot(explodeSound, 0.7f);
        }
        else
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, 0.4f);
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
