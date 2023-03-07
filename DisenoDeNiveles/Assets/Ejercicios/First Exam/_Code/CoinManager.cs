using System;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private Coin[] _coinList;

    public event Action CoinsUpdated;

    private void Start()
    {
        Prepare();
    }

    private void Prepare()
    {
        GameObject.FindGameObjectsWithTag("Coin");
    }

    private void AddCoin()
    {
        CoinsUpdated?.Invoke();
    }

    private void RemoveCoin(int amaunt)
    {
        CoinsUpdated?.Invoke();
    }

    private void SubscribeToCoins(Coin[] coinList)
    {
        foreach(Coin coin in coinList)
        {
            coin.OnCoinCollected += AddCoin;
        }
    }
}
