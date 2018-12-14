using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainScript : MonoBehaviour {

    Rigidbody2D body;
    Rigidbody2D head;
    Rigidbody2D leftArm;
    Rigidbody2D rightArm;
    Rigidbody2D leftLeg;
    Rigidbody2D rightLeg;
    float timer;
    public float force;


    // Use this for initialization
    void Start () {
        body = transform.GetChild(0).GetComponent<Rigidbody2D>();
        head = transform.GetChild(1).GetComponent<Rigidbody2D>();
        leftLeg = transform.GetChild(2).GetComponent<Rigidbody2D>();
        rightLeg = transform.GetChild(3).GetComponent<Rigidbody2D>();
        leftArm = transform.GetChild(4).GetComponent<Rigidbody2D>();
        rightArm = transform.GetChild(5).GetComponent<Rigidbody2D>();
        timer = Random.Range(50, 150);
    }
	
	// Update is called once per frame
	void Update () {
        timer--;
        
        if(timer == 0)
        {
            timer = Random.Range(50, 250);
            force = Random.Range(-45, 90);
        }
        if(force >= 0)
        {
            force -= 2;
        }

        body.AddForce(Vector2.up * force);
        //body.transform.Rotate(new Vector3(0, 0, 1*Time.deltaTime));
    }
}
