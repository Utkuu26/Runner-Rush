using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float laneSwitchSpeed;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartRunningAnimation();
    }

    void Update()
    {
        //Start butonuna basıldıysa burayı çalıştırıcazç
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if(this.gameObject.transform.position.x > GroundBoundaries.leftBoundary)
            {
                transform.Translate(Vector3.left * Time.deltaTime * laneSwitchSpeed);
            }
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if(this.gameObject.transform.position.x < GroundBoundaries.rightBoundary)
            {
                transform.Translate(Vector3.right * Time.deltaTime * laneSwitchSpeed);
            }
        }
        
    }

     void StartRunningAnimation()
    {
        animator.SetBool("isRun", true); 
    }
}
