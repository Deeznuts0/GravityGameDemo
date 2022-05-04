using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreup : MonoBehaviour
{
    public CoinPickUp p;
    [SerializeField]
    private int scorevalue = 1;
    [SerializeField]
    
   


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {

        if (c.gameObject.CompareTag("Player"))
         {
             p.AddCoin();


                

             Destroy(this.gameObject, .1f);
         }
     }
    }



