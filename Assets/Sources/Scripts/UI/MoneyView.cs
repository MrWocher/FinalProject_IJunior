using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class MoneyView : MonoBehaviour
{
    public static UnityAction<int> MoneyAdded;
    public static UnityAction<int> MoneyRemoved;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _moneyText;

    private int _initMoneyAmount = 0; 

    public int Money { get; private set; }

    private void OnEnable()
    {
        MoneyAdded += AddMoney;
        MoneyRemoved += RemoveMoney;

        Money = (PlayerPrefs.GetInt("Money") == _initMoneyAmount) ? _initMoneyAmount : PlayerPrefs.GetInt("Money");
        _moneyText.text = Money.ToString();
    }

    private void OnDisable()
    {
        MoneyAdded -= AddMoney;
        MoneyRemoved -= RemoveMoney;
    }

    private void AddMoney(int money)
    {
        Money += money;
        PlayerPrefs.SetInt("Money", Money);
        _moneyText.text = Money.ToString();
    }

    private void RemoveMoney(int money)
    {
        Money -= money;
        PlayerPrefs.SetInt("Money", Money);
        _moneyText.text = Money.ToString();
    }

}
