using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaController : MonoBehaviour {
    float speed;
    public GameObject explosion;
    public ShipHandler theShip;
    bool hit;
	// Use this for initialization
	void Start () {
        speed = UnityEngine.Random.Range(1, 10);
	}
	
	// Update is called once per frame
	void Update () {
        if (hit)
        {
            transform.Translate(0, -Time.deltaTime * theShip.speed, 0);
            transform.rotation = Quaternion.identity;
        }
        else
        {
            transform.Translate(-speed * Time.deltaTime, -speed / 2 * Time.deltaTime, 0f);
        }
        if (transform.position.y > theShip.transform.position.y + 20f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name != "asteroid-use")
        {
            transform.GetComponent<BoxCollider2D>().isTrigger = false;
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Destroy(gameObject, 0.4f);
            hit = true;
            theShip.ShipIsHit();
        }
    }
}
