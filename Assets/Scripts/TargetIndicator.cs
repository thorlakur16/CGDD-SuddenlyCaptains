using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour {

    public Transform target;
    public GameObject theShip;
    public float hide;
	
	// Update is called once per frame
	void Update () {
        var direction = target.position - theShip.transform.position;

        if(direction.magnitude < hide)
        {
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        } else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }

            var angle = Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
	}
}
