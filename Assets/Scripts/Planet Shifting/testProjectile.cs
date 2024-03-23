using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class testProjectile : MonoBehaviour
{
   // public Transform target;
    public float duration = 2f;
    public GameObject objectToLerp; // The GameObject to lerp
    public float upwardOffset = 2f; // The upward offset for the target position
    public bool reachedCenter;
    public Vector3 upwordPoint;
    private void Start()
    {
       // StartCoroutine(LerpToTarget());
     //  MoveToTarget();
    }

    public void MoveToTarget(Transform target)
    {
        if(GameManager.instance.startLookingAt){transform.LookAt(GameManager.instance.spawnedPlanet.transform);}
        var p = CalculateCentralPoint(objectToLerp.transform.position, target.position);
        objectToLerp.transform.DOMove(p, duration / 2).OnComplete((delegate
        {
            objectToLerp.transform.DOMove(target.position, duration / 2); }));
    }
    private Vector3 CalculateCentralPoint(Vector3 position1, Vector3 position2)
    {
        float centralX = (position1.x + position2.x) / 2f;
        float centralY = (position1.y + position2.y) / 2f;
        float centralZ = (position1.z + position2.z) / 2f;

        return new Vector3(centralX, centralY-10, centralZ);
    }
    /*private IEnumerator LerpToTarget(GameObject lerpObj,Transform currentTarget)
    {
       // float elapsedTime = 0;
        
    }*/
    
}
