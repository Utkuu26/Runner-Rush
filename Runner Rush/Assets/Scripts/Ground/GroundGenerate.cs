using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerate : MonoBehaviour
{
    [SerializeField] private GameObject[] groundPart;
    [SerializeField] private int zPos;
    private bool createGroundPart = false;
    private int partNo;

    void Start()
    {
        
    }

    void Update()
    {
        if(createGroundPart == false)
        {
            createGroundPart = true;
            StartCoroutine(GenerateGround());
        }
    }

    IEnumerator GenerateGround()
    {
        partNo = Random.Range(0, 5);
        Instantiate(groundPart[partNo], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 28;
        yield return new WaitForSeconds(3);
        createGroundPart = false;
    }
}
