using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaController : MonoBehaviour {
    float speed;
	// Use this for initialization
	void Start () {
        speed = UnityEngine.Random.Range(1, 10);

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-speed * Time.deltaTime, -speed/2 * Time.deltaTime, 0f);
        //transform.Rotate(0,0,speed * Time.deltaTime*10);
	}
}
