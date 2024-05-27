using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPuzzletrigger : MonoBehaviour
{
    public GameObject redGround;

    private Collider2D redGroundCollider;
    private SpriteRenderer redGroundRenderer;

    void Start()
    {
        if (redGround != null)
        {
            // Get the Collider2D and SpriteRenderer components from the redGround object
            redGroundCollider = redGround.GetComponent<Collider2D>();
            redGroundRenderer = redGround.GetComponent<SpriteRenderer>();

            if (redGroundCollider != null && redGroundRenderer != null)
            {
                // Ensure both the collider and the renderer are enabled initially
                redGroundCollider.enabled = true;
                redGroundRenderer.enabled = true;
            }
            else
            {
                Debug.LogError("Collider2D or SpriteRenderer component is missing on redGround.");
            }
        }
        else
        {
            Debug.LogError("Red Ground GameObject is not assigned.");
        }
    }

    // Assuming the button is represented by another GameObject with a Collider2D component
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable both the collider and the renderer when the player touches the button
            redGroundCollider.enabled = false;
            redGroundRenderer.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Enable both the collider and the renderer when the player leaves the button area
            redGroundCollider.enabled = true;
            redGroundRenderer.enabled = true;
        }
    }
}