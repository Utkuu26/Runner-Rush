using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] groundPartPrefabs;
    public List<GameObject> pooledGroundParts = new List<GameObject>();
    public List<int> activeGroundPartIndexes = new List<int>();

    void Start()
    {
        for (int i = 0; i < groundPartPrefabs.Length; i++)
        {
            GameObject prefab = groundPartPrefabs[i];
            GameObject groundPart = Instantiate(prefab, transform.position, Quaternion.identity);
            groundPart.SetActive(false);
            pooledGroundParts.Add(groundPart);
        }
    }

    public GameObject GetRandomGroundPart()
    {
        // Get a random index from the pool of ground parts
        int randomIndex = Random.Range(0, groundPartPrefabs.Length);
        
        // Check if the ground part is not already active
        while (activeGroundPartIndexes.Contains(randomIndex))
        {
            randomIndex = Random.Range(0, groundPartPrefabs.Length);
        }

        // Set the ground part as active and return it
        GameObject groundPart = pooledGroundParts[randomIndex];
        activeGroundPartIndexes.Add(randomIndex);
        return groundPart;
    }

    public void ReturnGroundPartToPool(GameObject groundPart)
    {
        int index = pooledGroundParts.IndexOf(groundPart);
        activeGroundPartIndexes.Remove(index);
        groundPart.SetActive(false);
    }
}
