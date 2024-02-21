using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float laneSwitchSpeed;
    [SerializeField] private float jumpHeight;
    private Animator animator;
    static public bool canMove = false;
    public bool isJumping = false;
    public bool isFalling = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Start butonuna basıldıysa burayı çalıştırıcazç
        if(canMove == true)
        {
            animator.SetBool("isRun", true);
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

            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            {
                if(isJumping == false)
                {
                    isJumping = true;
                    animator.SetBool("isJump", true); 
                    StartCoroutine(JumpSequence());
                }
            }
        }

        if(isJumping == true)
        {
            if(isFalling == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * jumpHeight, Space.World);
            }
            if(isFalling == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -jumpHeight, Space.World);
            }
        }
    }

    IEnumerator JumpSequence()
    {
        float initialPoseY = transform.position.y;
        yield return new WaitForSeconds(0.6f);
        isFalling = true;
        yield return new WaitForSeconds(0.6f);
        isJumping = false;
        isFalling = false;
        animator.SetBool("isJump", false); 
        transform.position = new Vector3(transform.position.x, initialPoseY, transform.position.z);
    }

}
