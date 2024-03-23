using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFolloTwo : MonoBehaviour
{
    public Transform target; // The target to follow (player car)
       public Vector3 offset; // Offset from the target's position
   
       public float smoothSpeed = 0.125f; // Speed at which the camera follows the target
       public Vector3 rotationOffset; // Additional rotation offset for the camera
   
       void FixedUpdate()
       {
           if (target == null)
           {
               Debug.LogWarning("Target is not assigned to the CameraController!");
               return;
           }
   
           Vector3 desiredPosition = target.position + offset;
           Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
           transform.position = smoothedPosition;
   
           transform.rotation = Quaternion.LookRotation(target.position - transform.position) * Quaternion.Euler(rotationOffset);
       }
}
