using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class VendingMachine : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TextMeshPro _costText;

    [Header("Settings")]
    [SerializeField] private int _price = 0;

    private bool Sold = false;

    public UnityEvent OnSaleMade;

    private void Awake()
    {
        UpdateCostText();
    }
    public void Interact()
    {
        Sell();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !Sold)
        {
            Sell();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !Sold)
        {
            Sell();
        }
    }

    private void Sell()
    {
        if (CoinManager.Instance.Coins >= _price)
        {
            CoinManager.Instance.RemoveCoin(_price);
            Sold = true;
            OnSaleMade?.Invoke();
        }
    }

    private void UpdateCostText()
    {
        _costText.text = _price.ToString();
    }



}
