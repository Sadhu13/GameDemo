using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.PixelArtPlatformer_VillageProps;

public class TriggerEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Chest chest; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger is the player or something else
        if (other.CompareTag("Player") || other.CompareTag("Interactable"))
        {
            // Open the chest
            chest.Open();
        }
    }

}
