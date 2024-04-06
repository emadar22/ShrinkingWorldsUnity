using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShapeShiftTrigger : MonoBehaviour
{
   private GameObject parentCapsule;
   public UnityEvent actionOnEnter,actionOnExit;
   public List<Collider> ColToActve;
   private void OnTriggerEnter(Collider col)
   {
      if (col.gameObject.layer==8)
      {
         print(col.gameObject.name+"  Triggered");
         if (actionOnEnter != null)
         {
            actionOnEnter.Invoke();
         }
      }
   }
   private void OnTriggerExit(Collider col)
   {
      if (col.gameObject.layer==8)
      {
        
         if (actionOnExit != null)
         {
            actionOnExit.Invoke();
            AtiveRequiredColliders();
         }
      }
   }
   void AtiveRequiredColliders()
   {
    if(FauxGravityAttractManager.ins.Allcolliders.Count>0){ FauxGravityAttractManager.ins.Allcolliders.ForEach(obj=>obj.enabled=false);}
     if(ColToActve.Count>0){ ColToActve.ForEach(obj=>obj.enabled=true);}
   }
 
}
