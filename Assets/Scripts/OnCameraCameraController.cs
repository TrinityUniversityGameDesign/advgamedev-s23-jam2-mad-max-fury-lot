using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class OnCameraCameraController : MonoBehaviour
{
    public GameObject target;    // The target object to follow
    public Vector3 currentVectorOfMovement;
    public Vector3 offset = new Vector3(0, 0, 0);   // The offset distance behind the target
    public float smoothTime = 0.3f;   // The smooth time for camera movement

    private Vector3 velocity = Vector3.zero;   // The current velocity of camera movement

    private void Start()
    {

    }

    void LateUpdate()
    {

        Debug.DrawLine(target.transform.position, target.transform.position + target.GetComponent<Rigidbody>().velocity.normalized, Color.green);

        // Calculate the camera position based on the target position and offset
        Vector3 targetPosition = target.transform.position - target.transform.forward + offset;
        Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Set the camera position
        transform.position = Vector3.Lerp(transform.position, newPosition, smoothTime);

        // Rotate the camera to always face the target object
        transform.LookAt(target.transform);
    }
}
