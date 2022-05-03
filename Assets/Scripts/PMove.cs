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

    public float xmov;
    public float zmov;
    private bool jumpTrigger;
    public GameObject Cam;

    public Vector3 moveDirection;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        xmov = Input.GetAxisRaw("Horizontal") * speed;
        zmov = Input.GetAxisRaw("Vertical") * speed;
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpTrigger = true;
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        moveDirection = ((forward * zmov) + (right * xmov));

        transform.rotation = Cam.transform.rotation;
        //transform.rotation = Quaternion.Euler(new Vector3(Cam.transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //horizontal movement
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

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
        if (col.gameObject.CompareTag("check")/*&& coins==5*/)
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


    }

    void SwitchGravity()
    {
        // Physics.gravity = new Vector3(0, -1.0F, 0);
        cg.gravityScale *= -1;
    }
}


