using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    
    // OnTriggerEnter2D is called when the Collider2D other enters the trigger
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("DeadZone");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Dead");
            GameManager.Instance.OnGameLose();
        }
    }
}
