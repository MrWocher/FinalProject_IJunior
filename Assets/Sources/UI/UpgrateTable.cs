using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgrateTable : MonoBehaviour
{
    [Header("Fire Rate")]
    [SerializeField] private TextMeshProUGUI _levelTxtrate;
    [SerializeField] private TextMeshProUGUI _costTxtrate;
    private int _levelRate = 1;
    private int _costRate = 100;

    [Header("Fire Range")]
    [SerializeField] private TextMeshProUGUI _levelTxtrange;
    [SerializeField] private TextMeshProUGUI _costTxtrange;
    private int _levelRange = 1;
    private int _costRange = 100;

    [Header("Other")]
    [SerializeField] private MoneyView _moneyView;

    private int _costPerUpgrate = 100;

    private void OnEnable()
    {
        _levelRate = (PlayerPrefs.GetInt("LevelRate") == 0) ? _levelRate : PlayerPrefs.GetInt("LevelRate");
        _levelRange = (PlayerPrefs.GetInt("LevelRange") == 0) ? _levelRange : PlayerPrefs.GetInt("LevelRange");

        _costRate = (PlayerPrefs.GetInt("CostRate") == 0) ? _costRate : PlayerPrefs.GetInt("CostRate");
        _costRange = (PlayerPrefs.GetInt("CostRange") == 0) ? _costRange : PlayerPrefs.GetInt("CostRange");

        UpdateRangeInfo();
        UpdateRateInfo();
    }

    private void UpdateRateInfo()
    {
        _levelTxtrate.text = "Level " + _levelRate.ToString();
        _costTxtrate.text = "$" + _costRate.ToString();
    }

    private void UpdateRangeInfo()
    {
        _levelTxtrange.text = "Level " + _levelRange.ToString();
        _costTxtrange.text = "$" + _costRange.ToString();
    }

    public void UpdateFireRate()
    {
        if(_moneyView.Money >= _costRate)
        {
            MoneyView.MoneyRemoved?.Invoke(_costRate);
            _levelRate++;
            _costRate += _costPerUpgrate;
            PlayerPrefs.SetInt("LevelRate", _levelRate);
            PlayerPrefs.SetInt("CostRate", _costRate);
            UpdateRateInfo();
        }
    }

    public void UpdateFireRange()
    {

        if(_moneyView.Money >= _costRange)
        {
            MoneyView.MoneyRemoved?.Invoke(_costRange);
            _levelRange++;
            _costRange += _costPerUpgrate;
            PlayerPrefs.SetInt("LevelRange", _levelRange);
            PlayerPrefs.SetInt("CostRange", _costRange);
            UpdateRangeInfo();
        }
    }
}
