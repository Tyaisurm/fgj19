using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    public CharacterController2D controller;
    public float runSpeed = 20f;
    public bool itemIsPickupable = false;
    public bool itemIsOperatable = false;
    float horizontalMove = 0f;

    bool jump = false;
    bool runFast = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("walkSpeed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("isJumping", true);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //if (runFast) { runFast = false; runSpeed = 20f; } else { runSpeed = 40f; runFast = true; }
            runSpeed = 40f;
        }
        else {
            runSpeed = 20f;
        }

        if (Input.GetKeyDown(KeyCode.E) && itemIsPickupable)
        {
            animator.SetTrigger("canPickUp");
        }
        else if (Input.GetKeyDown(KeyCode.E) && itemIsOperatable) {
            animator.SetTrigger("canOperate");
        }

    }

    public void OnLanding() {
        animator.SetBool("isJumping", false);
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
