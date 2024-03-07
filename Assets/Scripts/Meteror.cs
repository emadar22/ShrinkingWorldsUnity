using UnityEngine;

public class Meteror : MonoBehaviour
{
    // public variables
	public SphereCollider sphereCol;
	public ParticleSystem trail;

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        Quaternion rot = Quaternion.LookRotation(this.transform.position.normalized);
        //SoundManager.GetInstance().PlaySfxSoundWIthRequiredVol("meteorfalling",0.6f);
        rot *= Quaternion.Euler(90f, 0f, 0f);
        GameObject craterChild = Instantiate(GameManager.instance.createrPrefab, other.contacts[0].point, rot);

        sphereCol.enabled = false;
		trail.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        //SoundManager.GetInstance().StopSound(0.25f);
        Destroy(this.gameObject, 4f);
    }
    
}
