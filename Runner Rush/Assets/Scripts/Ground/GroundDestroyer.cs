// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class GroundDestroyer : MonoBehaviour
// {
//     private string parentObjectName;
//     [SerializeField] private ObjectPool objectPool;

//     void OnEnable()
//     {
//         StartCoroutine(DestroyGround());
//     }

//     IEnumerator DestroyGround()
//     {
//         yield return new WaitForSeconds(30);
//         objectPool.ReturnGroundPartToPool(gameObject);
//     }
// }
