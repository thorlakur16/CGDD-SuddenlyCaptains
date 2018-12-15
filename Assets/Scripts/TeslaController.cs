using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaController : MonoBehaviour {
    float speed;
    public ShipHandler theShip;
    bool hit;
    public AudioClip explosionSound;
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
            gameObject.GetComponent<AudioSource>().PlayOneShot(explosionSound, 0.4f);
            transform.GetComponent<BoxCollider2D>().isTrigger = false;
            gameObject.GetComponent<Animator>().SetTrigger("Explode");
            Destroy(gameObject, 0.4f);
            hit = true;
            theShip.ShipIsHit();
        }
    }
}
