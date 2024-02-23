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
    private bool isJumping = false;
    private bool isSliding = false;
    private bool isStanding = false;
    private BoxCollider playerCollider;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        //Start butonuna basıldıysa burayı çalıştırıcazç
        if(canMove == true)
        {
            animator.SetBool("isRun", true);
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > GroundBoundaries.leftBoundary)
                {
                    float newX = Mathf.Clamp(transform.position.x - 3f, GroundBoundaries.leftBoundary, GroundBoundaries.rightBoundary);
                    transform.position = new Vector3(newX, transform.position.y, transform.position.z);
                }
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < GroundBoundaries.rightBoundary)
                {
                    float newX = Mathf.Clamp(transform.position.x + 3f, GroundBoundaries.leftBoundary, GroundBoundaries.rightBoundary);
                    transform.position = new Vector3(newX, transform.position.y, transform.position.z);
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

            if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                if(isSliding == false)
                {
                    isSliding = true;
                    animator.SetBool("isSlide", true); 
                    StartCoroutine(SlideSequence());
                }
            }
        }

        if(isJumping == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime * jumpHeight, Space.World);
        }

        if(isSliding == true)
        {
            if(isStanding == false)
            {
                playerCollider.size = new Vector3(playerCollider.size.x, 0.5f, playerCollider.size.z);
                playerCollider.center = new Vector3(playerCollider.center.x, 0.25f, playerCollider.center.z);
            }
            if(isStanding == true)
            {
                playerCollider.size = new Vector3(playerCollider.size.x, 1f, playerCollider.size.z);
                playerCollider.center = new Vector3(playerCollider.center.x, 0.5f, playerCollider.center.z);
            }
        }
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(1f);
        isJumping = false;
        animator.SetBool("isJump", false); 
    }

    IEnumerator SlideSequence()
    {
        yield return new WaitForSeconds(0.6f);
        isStanding = true;
        yield return new WaitForSeconds(0.6f);
        isSliding = false;
        isStanding = false;
        animator.SetBool("isSlide", false); 
    }

}
