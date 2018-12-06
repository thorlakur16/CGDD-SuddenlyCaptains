using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float random = UnityEngine.Random.Range(0.7f, 1.2f);
        Destroy(gameObject, random);
        gameObject.transform.localScale = new Vector3(random, random, 0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
