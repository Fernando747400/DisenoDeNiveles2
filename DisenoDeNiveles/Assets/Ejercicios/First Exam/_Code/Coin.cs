using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject _coin;

    public event Action OnCoinCollected;

    private void Awake()
    {
        _coin = this.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnCoinCollected?.Invoke();
            _coin.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnCoinCollected?.Invoke();
            _coin.SetActive(false);
        }
    }
}
