using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Sprite[] _weaponsIcons;
    [SerializeField] private Image _weaponImg1;
    [SerializeField] private Image _weaponImg2;
    [SerializeField] private TextMeshProUGUI _levelTxt1;
    [SerializeField] private TextMeshProUGUI _levelTxt2;
    [SerializeField] private UpgrateWeapon _upgrateWeapon;

    private float _duractionAnim = 0.5f;
    private float _maxSliderValue = 1f;
    private float _minSliderValue = 0f;

    private void OnEnable()
    {
        _upgrateWeapon.ChangeWeaponLevelOnStarted += UpdateInfo;
        _upgrateWeapon.UpgratedWeapon += UpgrateLevel;

        UpdateInfo(_upgrateWeapon.WeaponLevel);
    }

    private void OnDisable()
    {
        _upgrateWeapon.ChangeWeaponLevelOnStarted += UpdateInfo;
        _upgrateWeapon.UpgratedWeapon -= UpgrateLevel;
    }

    private void UpgrateLevel(int level)
    {
        DOTween.Sequence()
            .Append(_slider.DOValue(_maxSliderValue, _duractionAnim))
            .AppendCallback(() => _slider.value = _minSliderValue);
        UpdateInfo(_upgrateWeapon.WeaponLevel);
    }

    private void UpdateInfo(int level)
    {
        _levelTxt1.text = (level + 1).ToString();
        _levelTxt2.text = (level + 2).ToString();

        _weaponImg1.sprite = _weaponsIcons[level];
        _weaponImg2.sprite = _weaponsIcons[level + 1];
    }
}
