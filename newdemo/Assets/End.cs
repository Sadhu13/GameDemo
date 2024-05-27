using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.PixelArtPlatformer_VillageProps;

public class End : MonoBehaviour
{   
    public GameObject canvas;


    void OnStart()
    {
        canvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            canvas.SetActive(true);
        }
    }
}