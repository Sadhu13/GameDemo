using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Interaction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Object1"))
        {
            Debug.Log("Player 1 touched Stone 1.");

            // Set Stone 1 as visible
            other.gameObject.SetActive(true);

            // Notify VisibilityController that Object 1 is visible
            VisibilityController visibilityController = FindObjectOfType<VisibilityController>();
            if (visibilityController != null)
            {
                visibilityController.SetObject1Visible(true);
            }
            else
            {
                Debug.LogError("VisibilityController not found in the scene.");
            }
        }
    }
}