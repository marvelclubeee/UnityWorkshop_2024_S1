using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // OnTriggerEnter2D is called when the Collider2D of the object enters the trigger
    public void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Collectable picked");
        if(other.CompareTag("Player")){ // check if the object that entered the trigger is the player
            GameManager.Instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
