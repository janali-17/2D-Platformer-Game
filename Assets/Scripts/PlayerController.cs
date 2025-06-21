using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string IS_RUNNING = "IsRunning";

    [SerializeField]private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
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
        animator.SetFloat(IS_RUNNING, Mathf.Abs(speed));

        if (speed < 0f) {
            spriteRenderer.flipX = true;
        }
        else if (speed > 0f)
        {
            spriteRenderer.flipX = false;
        }
    }
}
