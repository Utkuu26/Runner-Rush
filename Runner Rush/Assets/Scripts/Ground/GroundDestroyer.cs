using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour
{
    private string parentObjectName;

    void Update()
    {
        parentObjectName = transform.name;
        StartCoroutine(DestroyGround());
    }

    IEnumerator DestroyGround()
    {
        yield return new WaitForSeconds(13);
        if(parentObjectName == "GroundPart(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
