using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if player collider runs into coin collider, destroy coin
        if (other.gameObject.CompareTag("Player"))
        {
            //pick up coin, increase score
            DataHolderController.holdScore += 10;
            Destroy(gameObject);
            
        }
            
    }
}