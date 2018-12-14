using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    public ShipHandler theShip;
    public int spawnSize;
    public GameObject asteroid;
    public bool wave1 = false;
    public bool wave2 = false;
    public bool wave3 = false;
    public bool wave4 = false;
    public bool wave5 = false;
    public bool wave6 = false;
    public bool wave7 = false;
    public bool wave8 = false;
    public bool wave9 = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float shipY = theShip.transform.position.y;
        if (shipY < 900 && wave1 == false)
        {
            SpawnWave();
            wave1 = true;
        }
        if (shipY < 800 && wave2 == false)
        {
            SpawnWave();
            wave2 = true;
        }
        if (shipY < 700 && wave3 == false)
        {
            SpawnWave();
            wave3 = true;
        }
        if (shipY < 600 && wave4 == false)
        {
            SpawnWave();
            wave4 = true;
        }
        if (shipY < 500 && wave5 == false)
        {
            SpawnWave();
            wave5 = true;
        }
        if (shipY < 400 && wave5 == false)
        {
            SpawnWave();
            wave5 = true;
        }
        if (shipY < 300 && wave6 == false)
        {
            SpawnWave();
            wave6 = true;
        }
        if (shipY < 200 && wave6 == false)
        {
            SpawnWave();
            wave6 = true;
        }
    }
    public void SpawnWave()
    {
        for (int i = 0; i < spawnSize; i++)
        {
            float randomY = Random.Range(50, 150);
            float randomX = Random.Range(-150, 150);
            Vector3 spawnPosition = new Vector3(theShip.transform.position.x + randomX, theShip.transform.position.y - randomY, 0);
            Quaternion spawnRotation = Quaternion.identity;
            var instance = Instantiate(asteroid, spawnPosition, spawnRotation);
        }
    }
}
