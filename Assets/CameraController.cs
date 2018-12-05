using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public ShipHandler theShip;

    [SerializeField]
    Gradient gradient;
    [SerializeField]
    float duration = 3f;
    float t = 0f;
    Camera camera;

    // Use this for initialization
    void Start () {
        camera = GetComponent<Camera>();
        camera.clearFlags = CameraClearFlags.SolidColor;

    }
	
	// Update is called once per frame
	void Update () {
        t += 1;
        Debug.Log(t / 10000f);
        camera.backgroundColor = new Color(0,0,t/10000f,0);

    }
}
