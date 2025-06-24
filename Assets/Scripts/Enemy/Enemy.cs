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
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
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
    }
}
