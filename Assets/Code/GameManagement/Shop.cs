using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    [SerializeField] CoinManager coinManager;
    PlayerModifier playerModifier;

    private void Start()
    {
        playerModifier = FindAnyObjectByType<PlayerModifier>();
    }

    public void BuyWidth()
    {
        if(coinManager.numberOfCoins >= 20)
        {
            coinManager.SpendMoney(20);
            Progress.Instance.Coins = coinManager.numberOfCoins;
            Progress.Instance.Width += 25;
            playerModifier.SetWidth(Progress.Instance.Width);
        }
    }

    public void BuyHeight()
    {
        if (coinManager.numberOfCoins >= 20)
        {
            coinManager.SpendMoney(20);
            Progress.Instance.Coins = coinManager.numberOfCoins;
            Progress.Instance.Height += 25;
            playerModifier.SetHeight(Progress.Instance.Height);
        }
    }
}
