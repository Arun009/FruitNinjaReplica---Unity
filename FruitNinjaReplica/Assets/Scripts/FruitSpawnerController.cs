using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawnerController : MonoBehaviour {

    public GameObject fruitPrefab;
    public Transform[] spawnPoints;

    public float minDelay = 0.1f;
    public float maxDelay = 1.0f;
    
    // Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnFruits());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnFruits()
    {
        while(true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(1f);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedFruit, 5.0f);
        }
    }
}
