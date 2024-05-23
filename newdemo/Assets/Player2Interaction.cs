using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Interaction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Object2"))
        {
            Debug.Log("Player 2 touched Stone 2.");

            // Set Stone 2 as visible
            other.gameObject.SetActive(true);

            // Notify VisibilityController that Object 2 is visible
            VisibilityController visibilityController = FindObjectOfType<VisibilityController>();
            if (visibilityController != null)
            {
                visibilityController.SetObject2Visible(true);
            }
            else
            {
                Debug.LogError("VisibilityController not found in the scene.");
            }
        }
    }
}