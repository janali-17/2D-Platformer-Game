using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform wayPointA, wayPointB;
    [SerializeField] private float speed;

    private Vector3 currentTarget;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("EnemyIdle_Chomper"))
            return;
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        if(transform.position == wayPointA.position)
        {
            currentTarget = wayPointB.position;
            spriteRenderer.flipX = false;
        }
        else if  (transform.position == wayPointB.position) 
        { 
            currentTarget = wayPointA.position  ;
            spriteRenderer.flipX = true;

        }

        transform.position = Vector3.MoveTowards(transform.position,currentTarget,speed * Time.deltaTime);

        if(transform.position == currentTarget)
        {
            animator.SetTrigger("Idle");
        }
    }
}
