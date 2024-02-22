using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OncomingObstackle : MonoBehaviour
{
    [SerializeField] private GameObject player; // Karakter nesnesi
    [SerializeField] private GameObject obstaclePrefab; // Engel prefabı
    [SerializeField] private float spawnInterval = 1f; // Spawn aralığı (saniye)
    [SerializeField] private float obstacleSpeed = 400f; // Engel hızı
    [SerializeField] private float despawnDelay = 4f; // Karakterin konumunu geçtikten sonra engelin kaybolması süresi (saniye)
    [SerializeField] private float spawnDistance = 60f;

    private float nextSpawnTime; // Sonraki spawn zamanı

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval; // İlk spawn zamanını ayarla
    }

    void Update()
    {
        // Belirli aralıklarla engel spawn et
        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnObstacle()
    {
        GameObject newObstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.Euler(0f, 180f, 0f));

        // Karakterin önünden belirli bir mesafede spawn et, y değerini sabit olarak 0 olarak ayarla
        Vector3 spawnPosition = player.transform.position + player.transform.forward * spawnDistance;
        spawnPosition.y = 0f; // Y eksenini sabit olarak 0 yap
        newObstacle.transform.position = spawnPosition;

        // Karakterin pozisyonunu hedef olarak belirle
        Vector3 targetPosition = player.transform.position;

        // Yeni engelin yönünü ve hızını belirle
        Vector3 moveDirection = (targetPosition - spawnPosition).normalized;
        newObstacle.GetComponent<Rigidbody>().velocity = moveDirection * obstacleSpeed;

        // Engeli belirli bir süre sonra yok et
        Destroy(newObstacle, despawnDelay);
    }
}
