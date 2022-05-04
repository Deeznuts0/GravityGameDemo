using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PMove : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public float jumpheight;
    public CustomGravity cg;
    Vector3 direction;
    private float xmov;
    private float zmov;
    private bool jumpTrigger;
    public GameObject Cam;
   public CoinPickUp done;
   public Windy w;
    public float rotspeed;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        xmov = Input.GetAxisRaw("Horizontal");
        zmov = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpTrigger = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 zeroedVelocity = rb.velocity;
        zeroedVelocity.x = 0;
        zeroedVelocity.z = 0;
        rb.velocity = zeroedVelocity;

        // Rotate the player so that it always faces away from the camera
        Vector3 camRotation = Cam.transform.rotation.eulerAngles;
        camRotation.x = 0;
        camRotation.z = 0;
        rb.MoveRotation(Quaternion.Euler(camRotation));

        //horizontal movement
        direction = new Vector3(xmov * speed, rb.velocity.y, zmov * speed);
        
        //turning
        if (xmov != 0 || zmov != 0)
        {
            direction = transform.TransformDirection(direction);
            rb.velocity = direction;
        }

        //jumping
        if (jumpTrigger)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpheight, rb.velocity.z);
            jumpTrigger = false;
        }

        // if (isGrounded() && Input.GetButtonDown("Jump"))
        // {
        //     cg.gravityScale *= -1;
        // }
    }

    public bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.0f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("grav"))
        {
            SwitchGravity();
            audio.Play();
        }
        if (col.gameObject.CompareTag("check")&& done.coin>=5)
        {
            SceneManager.LoadScene("start");
        }

    }

    void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("death"))
        {
            SceneManager.LoadScene("start");
        }

        if (collision.gameObject.CompareTag("blog"))
        {
            w.blowable = true;
        }

    }

    void SwitchGravity()
    {
        // Physics.gravity = new Vector3(0, -1.0F, 0);
        cg.gravityScale *= -1;
    }
}


