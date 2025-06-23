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
    [SerializeField] private LayerMask _layerMask;

    private bool _resetJumpNeeded = false;
    private bool _isGrounded = false;
    private float jump;
    private bool crouch;


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
       // if(IsGrounded())jump = Input.GetAxisRaw("Jump");
        PLayerMovementAnimation(horizontal);
        PlayerMovement(horizontal);
    }


    private void PlayerMovement(float horizontal)
    {
        Vector3 postion = transform.position;
        postion.x +=  horizontal * speed * Time.deltaTime;
        transform.position = postion;
        _isGrounded = IsGrounded();

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded() )
        {
            Debug.Log("Space is being pressed");
            animator.SetBool(JUMP, true);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

    }

    private void PLayerMovementAnimation(float horizontal)
    {
        animator.SetFloat(IS_RUNNING, Mathf.Abs(horizontal));

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

    public void CollectKey()
    {
        int score = 10;
        scoreController.IncrementScore(score); 
    }
    private bool IsGrounded()
    {
        RaycastHit2D Hit = Physics2D.Raycast(transform.position, Vector2.down, .3f, _layerMask);
        Debug.DrawRay(transform.position, Vector2.down, Color.yellow);
        if (Hit.collider != null)
        {
            // Debug.Log("Grounded");
            if (_resetJumpNeeded == false)
            {
                animator.SetBool(JUMP, false);
                return true;
            }
        }
        return false;
    }

    IEnumerator resetJumpNeeded()
    {
        _resetJumpNeeded = true;
        yield return new WaitForSeconds(0.5f);
        _resetJumpNeeded = false;
    }
}
