using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    // OnTriggerEnter2D is called when the Collider2D of the object enters the trigger
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("DeadZone");
        if (other.CompareTag("Player")) // check if the object that entered the trigger is the player
        {
            Debug.Log("Player Dead");
            GameManager.Instance.OnGameLose();
        }
    }
}
