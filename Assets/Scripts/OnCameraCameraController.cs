using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class OnCameraCameraController : MonoBehaviour
{
    public Transform target;            // The target to follow
    public float followSpeed = 5f;      // The speed at which to follow the target
    public Vector3 offset = new Vector3(0f, 2f, -5f);  // The offset from the target's position

    private Vector3 targetPosition;     // The target position to move towards

    void Update()
    {
        // Set the target position to the target's position plus the offset
        targetPosition = target.position + offset;

        // Move the camera towards the target position with smoothing
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
