using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    public ShipHandler theShip;
    public int spawnSize;
    public GameObject asteroid;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    public void SpawnWave()
    {
        for (int i = 0; i < spawnSize; i++)
        {
            float randomY = Random.Range(50, 100);
            float randomX = Random.Range(-100, 100);
            Vector3 spawnPosition = new Vector3(theShip.transform.position.x + randomX, theShip.transform.position.y - randomY, 0);
            Quaternion spawnRotation = Quaternion.identity;
            var instance = Instantiate(asteroid, spawnPosition, spawnRotation);
        }
    }
}
