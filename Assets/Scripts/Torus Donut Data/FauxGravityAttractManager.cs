using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityAttractManager : MonoBehaviour
{
   public static FauxGravityAttractManager ins;
   [SerializeField] public GameObject GravityBody;
   public List<Collider> Allcolliders;
   public float gravity = -10f;
   
   private void Awake()
   {
      ins = this;
   }

   private void Start()
   {
      print("Gravity Started");
   }
   
   public void Attract(Rigidbody body) 
   {
      Vector3 gravityUp = (body.position -this.transform.position).normalized;
      body.AddForce(gravityUp * gravity);

      Quaternion targetRotation = Quaternion.FromToRotation(body.transform.up, gravityUp) * body.rotation;
      body.MoveRotation(targetRotation);
   }

   public void LerpTransform(Transform target)
   {
      StartCoroutine(LerpT(0.85f, target));
   }

   IEnumerator LerpT(float duration, Transform targetPos)
   {
      float elapsedTime = 0;
      Vector3 initialPosition =GravityBody. transform.position;
      Vector3 targetPosition = targetPos.position;

      while (elapsedTime < duration)
      {
         elapsedTime += Time.deltaTime;
         float t = Mathf.Clamp01(elapsedTime / duration);
        GravityBody. transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
         yield return null;
      }

      GravityBody. transform.position = targetPosition;
      GravityBody.transform.SetParent(targetPos, true); // Set parent and keep world position
      GravityBody.transform.localPosition = Vector3.zero; // Reset local position
   }
}
// FauxGravityAttractManager.ins.Attract(rb);