using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPickUp : MonoBehaviour
{
    public int coins;
    Text text;
    public static int coinAmount;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        //text.text = coinAmount.ToString();
    }

    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Coin")

        {
            Debug.Log("Coin collected!");
            coins = coins + 1;
            //Col.gameObject.SetActive(false);
            Destroy(Col.gameObject);
        }
    }
}