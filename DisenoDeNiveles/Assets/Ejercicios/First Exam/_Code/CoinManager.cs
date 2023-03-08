using System;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    private int _coins = 0;
    private GameObject[] _coinList;

    public event Action CoinsUpdated;
    public int Coins { get => _coins;}

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Prepare();
    }

    private void Prepare()
    {
        _coinList = GameObject.FindGameObjectsWithTag("Coin");
        SubscribeToCoins(_coinList);
    }

    private void AddCoin()
    {
        _coins++;
        CoinsUpdated?.Invoke();
    }

    public void RemoveCoin(int amount)
    {
        _coins = _coins - amount;
        CoinsUpdated?.Invoke();
    }

    private void SubscribeToCoins(GameObject[] coinList)
    {
        foreach(GameObject coin in coinList)
        {
            Coin coinScript = coin.GetComponent<Coin>();
            coinScript.OnCoinCollected += AddCoin;
        }
    }
}
