using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.PixelArtPlatformer_VillageProps;

public class TriggerEvent : MonoBehaviour
{
    public GameObject redGround; 

    private Collider2D redGroundCollider; 

    void Start()
    {

        redGroundCollider = redGround.GetComponent<Collider2D>();


        redGroundCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            redGroundCollider.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            redGroundCollider.enabled = false;
        }
    }
}
