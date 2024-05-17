using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public float smoothSpeed = 0.125f; // Smoothness of camera movement
   [SerializeField] private Vector3 offset;

    void Update()
    {
        if (target != null)
        {
            
            Vector3 targetPosition = target.position + offset;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
