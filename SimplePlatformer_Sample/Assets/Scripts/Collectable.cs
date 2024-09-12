using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // OnTriggerEnter2D is called when the Collider2D other enters the trigger
    public void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("Collectable picked");
        if(collider.CompareTag("Player")){
            GameManager.Instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
