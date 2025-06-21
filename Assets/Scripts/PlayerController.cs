using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string IS_RUNNING = "IsRunning";
    private const string JUMP = "Jump";
    private const string CROUCH = "Crouch";

    [SerializeField]private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;

    private float jump;
    private bool crouch;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        jump = Input.GetAxisRaw("Vertical");
        animator.SetFloat(IS_RUNNING, Mathf.Abs(speed));
        Jump();

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool(CROUCH, true);
        }
        else {
            animator.SetBool(CROUCH, false);

        }

        if (speed < 0f) {
            spriteRenderer.flipX = true;
        }
        else if (speed > 0f)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void Jump()
    {
        if (jump > 0)
        {
            animator.SetBool(JUMP, true);
        }
        else
        {
            animator.SetBool(JUMP, false);
        }

    }

}
