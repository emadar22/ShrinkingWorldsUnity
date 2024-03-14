using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerCollision : MonoBehaviour
{
    // public variables
    public GameObject deathEffect;
    public Animator ScreenAnimator;
    public GameObject pauseBtn;
    
    // private variables
    private AudioSource audioSource;
    private PlayerController playerController;
    
    /// </summary>
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        playerController = this.GetComponent<PlayerController>();
    }
    
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Meteror") {
            audioSource.Stop();

            // creates the deathEffect instance of the car
            Instantiate(deathEffect, this.transform.position, this.transform.rotation);

            PlayerController movement = this.GetComponent<PlayerController>();

            ScreenAnimator.SetTrigger("PlayerDead");
           UiManager.GetInstance().LevelFail();
            pauseBtn.SetActive(false);
            playerController.isDead = true;

            this.gameObject.SetActive(false);
        }

        if (other.gameObject.layer==7)  // Ai Car Detection
        {
            ScreenAnimator.SetTrigger("PlayerDead");
            SoundManager.GetInstance().PlaySfxSound("hit");
            UiManager.GetInstance().LevelFail();
            pauseBtn.SetActive(false);
            playerController.isDead = true;
        }
    }
}
