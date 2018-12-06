using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreator : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public ArrayList allAsteroids;

    void Start()
    {
        allAsteroids = new ArrayList();
        SpawnAsteroids();
    }

    void SpawnAsteroids()
    {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y) + 300, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                var instance = Instantiate(hazard, spawnPosition, spawnRotation);
                allAsteroids.Add(instance);
            }
        
    }
}
