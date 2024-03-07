using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{ 
    public GameObject prefabs; // Prefabs to instantiate
    public int numberOfPrefabs; // Number of prefabs to instantiate
    public float sphereRadius = 5f; // Radius of the sphere
    public float spawnHeight = 1f; // Height above the sphere surface to spawn objects
    public bool allowOverlap = false; // Whether to allow overlap of instantiated objects

    void Start()
    {
        InstantiatePrefabs();
    }

    void InstantiatePrefabs()
    {
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            // Get a random point on the surface of the sphere
            Vector3 randomPoint = Random.onUnitSphere * sphereRadius;

            // Add the spawn height to the y-coordinate
            randomPoint.y += spawnHeight;

            // Instantiate a random prefab at the random point
           // GameObject prefabToInstantiate = prefabs[Random.Range(0, prefabs.Length)];
            GameObject instantiatedPrefab = Instantiate(prefabs, randomPoint, Quaternion.identity);

            // Optional: Check for overlap if not allowed
            if (!allowOverlap)
            {
                Collider[] colliders = instantiatedPrefab.GetComponentsInChildren<Collider>();
                foreach (Collider col in colliders)
                {
                    Collider[] overlaps = Physics.OverlapSphere(col.transform.position, 0.1f);
                    if (overlaps.Length > 1) // Overlaps with other colliders
                    {
                        Destroy(instantiatedPrefab);
                        return; // Retry instantiation
                    }
                }
            }
        }
    }
}
