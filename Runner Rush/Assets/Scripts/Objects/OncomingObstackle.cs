using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OncomingObstackle : MonoBehaviour
{
    [SerializeField] private GameObject player; 
    [SerializeField] private GameObject obstaclePrefab; 
    [SerializeField] private float spawnInterval = 1f; 
    [SerializeField] private float obstacleSpeed = 400f; 
    [SerializeField] private float despawnDelay = 4f; 
    [SerializeField] private float spawnDistance = 60f;

    private float nextSpawnTime; 

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnObstacle()
    {
        GameObject newObstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.Euler(0f, 180f, 0f));

        Vector3 spawnPosition = player.transform.position + player.transform.forward * spawnDistance;
        spawnPosition.y = 0f; 
        newObstacle.transform.position = spawnPosition;

        Vector3 targetPosition = player.transform.position;
        Vector3 moveDirection = (targetPosition - spawnPosition).normalized;
        newObstacle.GetComponent<Rigidbody>().velocity = moveDirection * obstacleSpeed;

        Destroy(newObstacle, despawnDelay);
    }
}
