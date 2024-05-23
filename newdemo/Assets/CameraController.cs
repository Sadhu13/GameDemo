using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    public float smoothTime = 0.5f;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (player1 == null || player2 == null)
            return;

        Vector3 midpoint = (player1.position + player2.position) / 2f;

        float distance = (player1.position - player2.position).magnitude;

        float cameraDistance = Mathf.Clamp(distance, 10f, 20f);

        Vector3 newPosition = midpoint - transform.forward * cameraDistance;
        newPosition.z = -10f; // Keep the camera in 2D mode

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
}
