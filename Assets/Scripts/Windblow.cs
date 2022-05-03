using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windblow : MonoBehaviour
{
    public float blowtime;
    public float blowstart =5;
    public Vector3 blow;
    public bool blowable = false;
    public rigidbody blower;

    // Start is called before the first frame update
    void Start()
    {
        blowtime = blowstart;
        
    }

    // Update is called once per frame
    void Update()
    {
        blowtime -= Time.deltaTime;
        if (blowtime <= 0)
        {
            BlowMe();
            blowtime = blowstart;
        }
    }
    void BlowMe()
    {
        if(blowable == true)
        {
            blower.addForce(30,0,0);
        }
    }


}
