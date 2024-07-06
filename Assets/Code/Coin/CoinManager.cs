using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int numberOfCoins;
    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        numberOfCoins = Progress.Instance.Coins;
        text.text = numberOfCoins.ToString();
    }

    public void AddOne()
    {
        numberOfCoins++;
        text.text = numberOfCoins.ToString();
    }

    public void SaveToProgress()
    {
        Progress.Instance.Coins = numberOfCoins;
    }

    public void SpendMoney(int value)
    {
        numberOfCoins -= value;
        text.text = numberOfCoins.ToString();
    }
}
