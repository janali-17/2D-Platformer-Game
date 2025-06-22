using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
         if(other.gameObject.GetComponent<PlayerController>() != null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
    }
}
