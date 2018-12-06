using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour {

    public Transform target;
    public GameObject theShip;
    public float hide;
	
	// Update is called once per frame
	void Update () {
        var direction = target.transform.position - theShip.transform.position;

        if(direction.magnitude < hide)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        } else
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;

            var angle = Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg;
            transform.GetChild(0).transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
	}
}
