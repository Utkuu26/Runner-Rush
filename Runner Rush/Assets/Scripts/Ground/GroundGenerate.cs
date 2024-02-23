using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerate : MonoBehaviour
{
    public ObjectPool objectPool;
    public List<GameObject> activeGroundParts = new List<GameObject>();
    public int maxGroundParts = 5;
    public float spawnInterval = 2f;
    private float currentInterval = 0f;

    private float zPos = 28f; // Z pozisyonu

    void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
        if (objectPool == null)
        {
            Debug.LogError("ObjectPool component is not found in the scene!");
        }
    }

    void Update()
    {
        currentInterval += Time.deltaTime;
        if (currentInterval >= spawnInterval)
        {
            currentInterval = 0f;
            SpawnGroundPart();
        }
    }

    void SpawnGroundPart()
    {
        if (activeGroundParts.Count < maxGroundParts)
        {
            GameObject groundPartObject = objectPool.GetRandomGroundPart();
            if (groundPartObject != null)
            {
                groundPartObject.transform.position = new Vector3(0, 0, zPos); // Z pozisyonunu ayarla
                zPos += 28; // Z pozisyonunu artır
                activeGroundParts.Add(groundPartObject);
                groundPartObject.SetActive(true);
                StartCoroutine(ReturnGroundPartCoroutine(groundPartObject));
            }
        }
    }

    IEnumerator ReturnGroundPartCoroutine(GameObject groundPart)
    {
        yield return new WaitForSeconds(20f);
        objectPool.ReturnGroundPartToPool(groundPart);
        activeGroundParts.Remove(groundPart);
    }
}
