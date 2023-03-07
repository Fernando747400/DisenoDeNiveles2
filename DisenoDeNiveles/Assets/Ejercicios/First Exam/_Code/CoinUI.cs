using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TextMeshProUGUI _coinText;

    private void Start()
    {
        UpdateCoinText();
        CoinManager.Instance.CoinsUpdated += UpdateCoinText;
    }

    private void OnEnable()
    {
        CoinManager.Instance.CoinsUpdated += UpdateCoinText;
    }

    private void OnDisable()
    {
        CoinManager.Instance.CoinsUpdated -= UpdateCoinText;
    }

    private void UpdateCoinText()
    {
        _coinText.text = CoinManager.Instance.Coins.ToString();
    }
}
