using UnityEngine;
using TMPro;

public class TableCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private UpgrateWeapon _upgrateWeapon;

    private void OnEnable()
    {
        _upgrateWeapon.UpgratedWeapon += ChangeLevelTxt;
        _upgrateWeapon.ChangeWeaponLevelOnStarted += ChangeLevelTxt;
    }
    private void OnDisable()
    {
        _upgrateWeapon.UpgratedWeapon -= ChangeLevelTxt;
        _upgrateWeapon.ChangeWeaponLevelOnStarted -= ChangeLevelTxt;
    }

    public void ChangeLevelTxt(int level)
    {
        _text.text = (level + 1).ToString();
    }

    public void Disactivate()
    {
        gameObject.SetActive(false);
    }

}
