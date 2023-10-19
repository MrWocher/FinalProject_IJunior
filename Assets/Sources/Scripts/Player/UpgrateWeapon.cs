using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using System;

public class UpgrateWeapon : MonoBehaviour
{
    public event Action<int> UpgratedWeapon;
    public event Action<int> ChangeWeaponLevelOnStarted;

    [SerializeField] private GameObject[] _weapons;
    [SerializeField] private PlayerShoot _playerShoot;
    [SerializeField] private Animator _animator;

    private int _initLevelNum = 0;
    private float _duractionAnim = 0.1f;

    public int WeaponLevel { get; private set; }

    private void OnEnable()
    {
        WeaponLevel = (PlayerPrefs.GetInt("WeaponLevel") == _initLevelNum) ? _initLevelNum : PlayerPrefs.GetInt("WeaponLevel");
        ChangeWeapon();
        ChangeWeaponLevelOnStarted?.Invoke(WeaponLevel);
    }

    public void Upgrate()
    {
        if (WeaponLevel < _weapons.Length - 1)
        {
            WeaponLevel++;
            PlayerPrefs.SetInt("WeaponLevel", WeaponLevel);
        }
        _playerShoot.StopShoot();
        _animator.enabled = false;
        DOTween.Sequence()
            .Append(transform.DORotate(new Vector3(-6f, 180f, 0f), _duractionAnim))
            .AppendCallback(ChangeWeapon)
            .Append(transform.DORotate(new Vector3(-6f, 360f, 0f), _duractionAnim))
            .AppendCallback(End);
        UpgratedWeapon?.Invoke(WeaponLevel);
    }

    private void ChangeWeapon()
    {
        foreach(GameObject i in _weapons)
            i.SetActive(false);
        _weapons[WeaponLevel].SetActive(true);
    }

    private void End()
    {
        _playerShoot.StartShoot();
        _animator.enabled = true;
    }
}
