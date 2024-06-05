using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    private Transform currentPlayer; // Reference to the current target (player or alien)
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset; // Offset between camera and target

    private void LateUpdate()
    {
        if (currentPlayer != null)
        {
            Vector3 desiredPosition = currentPlayer.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        currentPlayer = newTarget;
        // Optionally, update the offset if needed
        offset = transform.position - currentPlayer.position;
    }
}
