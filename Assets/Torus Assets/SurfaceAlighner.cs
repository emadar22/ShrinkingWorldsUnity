using UnityEngine;

public class SurfaceAlighner : MonoBehaviour
{
    public float raycastDistance = 1f;
    public float alignSpeed = 5f;
    public float attractionForce = 10f;
    public LayerMask layerMask;

    private Rigidbody rb;
    public Vector3 targetPosition;

    public float moveSpeed = 5f; // Speed of left/right movement
    public float rotationSpeed = 100f; // Speed of rotation
    public float forwardSpeed = 10f; // Speed of forward movement
    public bool TargetBelowFound;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Always move forward
        float verticalInput = 1f;
        transform.Translate(Vector3.forward * verticalInput * forwardSpeed * Time.deltaTime);

        // Left/right movement and rotation
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            // Move left/right
            transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
            
            // Rotate towards the movement direction
            Quaternion targetRotation = Quaternion.Euler(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);
            transform.rotation *= targetRotation;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, raycastDistance, layerMask))
        {
            TargetBelowFound = true;
            Vector3 surfaceNormal = hit.normal;
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, surfaceNormal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, alignSpeed * Time.deltaTime);

            // Set the target position to the hit point
            targetPosition = hit.point;
            Debug.DrawRay(transform.position, -transform.up * 100, Color.red);
            // Calculate direction to the hit point
            Vector3 direction = targetPosition - transform.position;

            // Apply attraction force towards the hit point
            rb.AddForce(direction.normalized * attractionForce);
        }
        else
        {
            TargetBelowFound = false;
        }
    }
}


