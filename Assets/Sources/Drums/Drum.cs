using System;
using UnityEngine;

public class Drum : MonoBehaviour
{
    [SerializeField] private DrumInWeapon _drumInWeapon;
    [SerializeField] private FollowPlayer _followPlayer;
    [SerializeField] private AudioSource _audioSource;
	[SerializeField] private AudioClip _reloadSound;
    [SerializeField] private GameObject[] _drumsBullets;

    private event Action BulletAdded;

    private Vector3 _targetRotate;

    private float _rotateSpeed = 5f;
    private float _maxDegrees = 360f;
    private int _maxBulletAmoutUp = 2;

    public int MaxBulletsAmount { get {  return _drumsBullets.Length; } }
    public int CurrentBullet { get; private set; }
    private float _perRotate { get { return _maxDegrees / (MaxBulletsAmount * _maxBulletAmoutUp); } }


    private void Start()
    {
        CurrentBullet = (PlayerPrefs.GetInt("BulletsInDrum") == 0 || PlayerPrefs.GetInt("BulletsInDrum") == MaxBulletsAmount) ? 0 : PlayerPrefs.GetInt("BulletsInDrum");
        for(int i = 0; i < _drumsBullets.Length; i++)
        {
            _drumsBullets[i].SetActive(false);
        }
        for(int i = 0; i < CurrentBullet; i++)
        {
            _drumsBullets[i].SetActive(true);
        }
    }

    private void OnEnable()
    {
        BulletAdded += AddBullet;
    }

    private void OnDisable()
    {
        BulletAdded += AddBullet;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, _targetRotate.z), _rotateSpeed * Time.deltaTime);
    }

    public void OnAddBullet()
    {
        BulletAdded?.Invoke();
    }

    public void DeleteBullet()
    {
        if(CurrentBullet > 0)
        {
            _targetRotate.z += _perRotate;
            CurrentBullet--;
            _drumsBullets[CurrentBullet].SetActive(false);
            PlayerPrefs.SetInt("BulletsInDrum", CurrentBullet);
        }
    }

    private void AddBullet()
    {
        if (CurrentBullet < MaxBulletsAmount)
        {
            _targetRotate.z -= _perRotate;
            _drumsBullets[CurrentBullet].SetActive(true);
            CurrentBullet++;
            PlayerPrefs.SetInt("BulletsInDrum", CurrentBullet);
            _audioSource.PlayOneShot(_reloadSound);
        }
    }

    public void TransitToWeaponStage()
    {
        _drumInWeapon.CurrentBullets = CurrentBullet;

        _drumInWeapon.enabled = true;
        _followPlayer.enabled = false;
        this.enabled = false;
    }

}
