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
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private ScoreController scoreController;

    private float jump;
    private bool crouch;


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        jump = Input.GetAxisRaw("Jump");
        PLayerMovementAnimation(horizontal);
        PlayerMovement(horizontal);
    }


    private void PlayerMovement(float horizontal)
    {
        Vector3 postion = transform.position;
        postion.x +=  horizontal * speed * Time.deltaTime;
        transform.position = postion;

        if(jump > 0)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
        }
    }

    private void PLayerMovementAnimation(float horizontal)
    {
        animator.SetFloat(IS_RUNNING, Mathf.Abs(horizontal));
        Jump();

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool(CROUCH, true);
        }
        else {
            animator.SetBool(CROUCH, false);

        }

        if (horizontal < 0f) {
            spriteRenderer.flipX = true;
        }
        else if (horizontal > 0f)
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
    public void CollectKey()
    {
        int score = 10;
        scoreController.IncrementScore(score); 
    }
}
