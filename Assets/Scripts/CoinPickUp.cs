using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPickUp : MonoBehaviour
{
    public int coin = 0;
    public Text coinText;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        AddCoin();
    }

    void AddCoin()
    {
        coin++;
        coinText.text = coin.ToString();
    }
}