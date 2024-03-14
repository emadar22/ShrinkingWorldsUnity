using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AiController : MonoBehaviour
{
    private Rigidbody rb;
    [Range(0.5f, 2)]
    public float moveSpeed;
    [Range(5, 100)]
    public float rototionSpeed;
    [Tooltip("Initial value Is 1 or -1")]
    [Range(-1,1)]
    public float rotation;
    public float lerpSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + this.transform.forward * -moveSpeed * Time.fixedDeltaTime);
        Vector3 rotationY = Vector3.up * rotation * rototionSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(rotationY);
        Quaternion targetRotation = rb.rotation * deltaRotation;
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.fixedDeltaTime));    
    }

    void ManageSpeed()
    {
        rotation = Mathf.Lerp(rotation, LerpRotationValues(rotation), Time.deltaTime * lerpSpeed);
    }
  
   
    float LerpRotationValues(float cValue)
    {
        return cValue == 1f ? -1f : 1f;
    }
}
