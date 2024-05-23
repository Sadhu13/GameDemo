using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityController : MonoBehaviour
{
    public GameObject winImage; // The image to show when both stone objects are touched

    private static bool isObject1Visible = false;
    private static bool isObject2Visible = false;

    void Start()
    {
        // Ensure the win image is set inactive initially
        if (winImage != null)
        {
            winImage.SetActive(false);
        }
        else
        {
            Debug.LogError("Win image not assigned.");
        }
    }

    public void SetObject1Visible(bool isVisible)
    {
        isObject1Visible = isVisible;
        CheckWinCondition();
    }

    public void SetObject2Visible(bool isVisible)
    {
        isObject2Visible = isVisible;
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        // Check if both stone objects are visible
        if (isObject1Visible && isObject2Visible)
        {
            Debug.Log("You win!");
            if (winImage != null)
            {
                winImage.SetActive(true); // Show the win image
                Time.timeScale = 0; // Pause the game
            }
        }
    }
}