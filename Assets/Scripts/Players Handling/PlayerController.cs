
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // public varaibles
    [Range(0,15)]
    public float moveSpeed;

    [Range(50, 250)]
    public float rototionSpeed;
    public TMP_Text scoreText;

    [HideInInspector]
    public bool isDead;
    

    // private varaibles
    private Rigidbody rb;
    private float rotation;
    private float score;
    
    void Start()
    {
        // initailize the private varaibles
        rb = this.GetComponent<Rigidbody>();
        isDead = false;
        score = 0.0f;
    }

   
    void Update()
    {
        // gets the rotation value from input axis
        rotation = Input.GetAxisRaw("Horizontal");
        if(scoreText == null)
            return;
        if(!isDead) {
            score = score + Time.deltaTime;
            scoreText.text = "Score:" + score.ToString("0.00");
        }
    }

   
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    void FixedUpdate()
    {
        // moves the player in its front direction
        rb.MovePosition(rb.position + this.transform.forward * -moveSpeed * Time.fixedDeltaTime);

        // rotates the car with input
        Vector3 rotationY = Vector3.up * rotation * rototionSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(rotationY);
        Quaternion targetRotation = rb.rotation * deltaRotation;
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.fixedDeltaTime));    
    }

    void OnTriggerEnter(Collider col) //coin Detection
    {
        if (col.gameObject.layer==6) // Coins Layer
        {
            UiManager.GetInstance().SpawnCoin();
            SoundManager.GetInstance().PlaySfxSound("coin");
            UiManager.GetInstance().UpdateBarFilling();
            Destroy(col.gameObject);
        }
    }
}


/*
Let's Elevate Your Digital Presence: Schedule a Meeting Today!

Dear [Client's Name],

I hope this message finds you well. My name is [Your Name], and I specialize in crafting tailored digital solutions designed to enhance businesses like yours.

I've been impressed by your [mention something specific about the client or their business, if applicable] and believe that we could collaborate effectively to achieve your objectives. At [Your Company Name], we offer a comprehensive range of services aimed at enhancing your digital presence and driving tangible results:

Website Development: Transform your online presence with custom-built websites that captivate your audience and drive engagement.

Mobile App Development: Bring your app ideas to life with user-friendly interfaces and seamless functionalities, crafted using cutting-edge technologies.

Game Development: Turn your gaming concepts into immersive experiences that resonate with your target audience across various platforms.

Custom Solutions: Tailored solutions to address your unique challenges and propel your business forward, no matter the complexity.

CMS Development: Enhance your website's performance and flexibility with custom content management systems tailored to your specific needs.

E-commerce Solutions (Shopify & WordPress): From design to SEO and payment integration, we ensure a seamless online shopping experience for your customers.

SEO Services: Improve your online visibility and drive more traffic to your website with our proven search engine optimization strategies.

Social Media Services: Elevate your social media presence with captivating designs, engaging content, and targeted marketing campaigns across various platforms.

API Integrations: Seamlessly integrate your systems and applications to optimize efficiency and enhance user experiences.

Webflow Development: Streamline your website development process with Webflow, offering simplicity and elegance in design.

Community Management & Sound Design: Engage your audience effectively through community management strategies tailored to your brand, along with high-quality sound design services.

I am confident that a discussion between us could unveil exciting opportunities for collaboration. Would you be available for a meeting in the coming days to explore how we can work together to achieve your business goals?

Please let me know your availability, and I'll be more than happy to arrange a meeting at your convenience. In the meantime, feel free to visit our website at [Your Website URL] to learn more about our services and past projects.

Thank you for considering [Your Company Name] as your partner in digital innovation. I look forward to the opportunity to work together and help you achieve success.

Best regards,

[Your Name]
[Your Position]
[Your Company Name]
[Your Contact Information]
*/
