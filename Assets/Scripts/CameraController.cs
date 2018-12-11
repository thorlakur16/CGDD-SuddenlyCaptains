using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public ShipHandler theShip;

    public GameObject thePlanetGround;
    private Camera camera;
    float distance;

    // Use this for initialization
    void Start () {
        camera = GetComponent<Camera>();
        camera.clearFlags = CameraClearFlags.SolidColor;
        distance = Mathf.Abs(thePlanetGround.transform.position.y - theShip.transform.position.y);
    }
	
	// Update is called once per frame
	void Update ()
    {
        float currentlytraveled = Mathf.Abs(thePlanetGround.transform.position.y - theShip.transform.position.y);
        float currentDistance = distance - currentlytraveled;

        camera.backgroundColor = new Color(0,0,currentDistance/distance/5,0);

    }
}
