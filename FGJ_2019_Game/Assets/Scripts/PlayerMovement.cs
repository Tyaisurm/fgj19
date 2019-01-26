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

    AudioSource audioS;

    public AudioClip[] footSteps;
    public AudioClip pickUpSound;

    bool jump = false;
    //bool runFast = false;
    bool crouching = false;

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponentInParent<AudioSource>();
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
        if (Input.GetKey(KeyCode.LeftShift) && !crouching)
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

        if (Input.GetKeyDown(KeyCode.DownArrow) && runSpeed == 20f)
        {
            crouching = true;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            crouching = false;
        }

    }

    public void OnLanding() {
        animator.SetBool("isJumping", false);
        DoubleStep();
    }

    public void OnCrouching(bool isCrouching) {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouching, jump);
        jump = false;
    }
    public void Step() {
        //
        audioS.volume = Random.Range(0.8f, 1.0f);
        audioS.pitch = Random.Range(0.08f,1.1f);
        audioS.PlayOneShot(footSteps[Random.Range(0, 1)]);//footStepTwo
    }
    public void DoubleStep()
    {
        Step();
        Step();
    }
    public void StashItem() {
        audioS.volume = 1.0f;
        audioS.pitch = 1.0f;
        audioS.PlayOneShot(pickUpSound,1.0f);
    }
}
