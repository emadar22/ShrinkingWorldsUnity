using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityAttractor : MonoBehaviour
{
    public static FauxGravityAttractor instance;

   
    // public varaibles
    public float gravity = -10f;

    // private varaibles
    private SphereCollider col;

    private void Start()
    {
        
    }
    private void Awake() {
        instance = this;
        col = instance.GetComponent<SphereCollider>();
    }

    public void PlaceOnSurface(Rigidbody bodyRB) {
      //  bodyRB.MovePosition((bodyRB.position - this.transform.position).normalized * (transform.localScale.x * col.radius));
    }

    public void Attract(Rigidbody body) 
    {
        Vector3 gravityUp = (body.position - this.transform.position).normalized;

        body.AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(body.transform.up, gravityUp) * body.rotation;
        body.MoveRotation(targetRotation);
    }
    public void LerpTransform(Transform target)
    {
        StartCoroutine(LerpT(0.8f, target));
    }

    IEnumerator LerpT(float duration, Transform targetPos)
    {
        float elapsedTime = 0;
        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = targetPos.position;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            yield return null;
        }

        transform.position = targetPosition;
        transform.SetParent(targetPos, true); // Set parent and keep world position
        transform.localPosition = Vector3.zero; // Reset local position
    }
}
