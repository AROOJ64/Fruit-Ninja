using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpwnar : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    public float minDistance = 5f;
    public float maxDistance = 20f;
    public float spawnInterval = 7f;

    public float left;
    public float right;

    void Start()
    {
        GameObject Sowrd = GameObject.FindGameObjectWithTag("Sowrd");
        InvokeRepeating("SpawnPrefab", 0f, spawnInterval);
    }

    void SpawnPrefab()
    {
        float force = Random.Range(14, 17);
        //random direction and distance 
        Vector3 randomDirection = Random.insideUnitSphere;
        float randomDistance = Random.Range(minDistance, maxDistance);
        randomDirection.y = 0f;
        GameObject Sowrd = GameObject.FindGameObjectWithTag("Sowrd");
        // Calculate the spawn on the Sowrd's pos,dir,distance.
        Vector3 spawnPosition = Sowrd.transform.position + randomDirection.normalized * randomDistance;
        GameObject spawnedPrefab = Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);
        spawnedPrefab.GetComponent<Rigidbody>().AddForce(RandomVector() * force, ForceMode.Impulse);
        spawnedPrefab.transform.rotation = Random.rotation;
        Destroy(spawnedPrefab, 20f);
    }
    private Vector2 RandomVector()
    {
        Vector2 moveDirection = new Vector2(Random.Range(left, right), 1).normalized;
        return moveDirection;   
    }
}
