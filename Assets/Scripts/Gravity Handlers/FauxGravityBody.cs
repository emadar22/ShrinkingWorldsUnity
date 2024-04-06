using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FauxGravityBody : MonoBehaviour
{
    // public varailables
    private FauxGravityAttractor fauxGravityAttractor;
    public bool placeOnSurface;

    // private varaibles
    private Rigidbody rb;

    
    /// <summary>
    // Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // get the only instance of attractor
        fauxGravityAttractor = FauxGravityAttractor.instance;

        // setup the rigidbody consraints
        rb = this.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;        
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if(placeOnSurface) {
            fauxGravityAttractor.PlaceOnSurface(rb);
        } 
        GravityAttracxtor().Attract(rb);     
       // FauxGravityAttractManager.ins.Attract(rb);
    }

    public FauxGravityAttractor gravityAttractor;
    public FauxGravityAttractor GravityAttracxtor()
    {
        gravityAttractor = FauxGravityAttractor.instance;
        if (!gravityAttractor) gravityAttractor = FindObjectOfType<FauxGravityAttractor>();
        return gravityAttractor;
    }
}
