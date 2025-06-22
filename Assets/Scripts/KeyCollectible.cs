using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollectible : MonoBehaviour
{
    private const string KEY_COLLECTED = "KeyCollected";

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            animator.SetTrigger(KEY_COLLECTED);
            StartCoroutine(KeyGoesUp());
            player.CollectKey();
            Destroy(gameObject , 1.5f);
        }
    }

    private IEnumerator KeyGoesUp()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + Vector3.up * 2f;
        float duration = 1f; // duration in seconds
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
    }
}
