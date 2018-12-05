using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    public Animator animator;
    public float rotation;
    public float speed;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        //transform.Translate(0, Time.deltaTime * speed, 0);
        transform.Rotate(0, 0, Time.deltaTime * rotation);
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //play animation explode
        animator.SetTrigger("Explode");
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        Destroy(gameObject, 0.4f);
        //
    }
}
