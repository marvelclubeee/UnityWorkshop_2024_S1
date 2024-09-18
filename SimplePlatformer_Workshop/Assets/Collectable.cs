using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // calls when a collider touches the trigger 
    private void OnTriggerEnter2D(Collider2D other){
        // check if the collider is the player, if not, then exit this function
        if(!other.gameObject.CompareTag("Player")){ return; }

        Debug.Log(other.gameObject.name + " touched " + gameObject.name);

        // "collects" the coin
        GameManager.Instance.AddScore(1); // add score
        Destroy(gameObject); // destroy the collectable
    }
}
