using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windy : MonoBehaviour
{
    public Rigidbody player;
    public float orgtime;
    public float blowtime;
    public bool blowable;
    public Vector3 wind;
    public GameObject p;

    // Start is called before the first frame update
    void Start()
    {
        blowtime = orgtime;

    }

    // Update is called once per frame
    void Update()
    {
        blowtime -= Time.deltaTime;
        if(blowtime <= 0 && blowable == true)
        {
            Blow();
        }
    }

    void Blow()
    {
        player.AddForce(wind, ForceMode.Impulse);
        blowtime = orgtime;
    }

    public void onCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Player")
        {
            blowable = true;
        }
       
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            blowable = false;
        }
        
    }

}
