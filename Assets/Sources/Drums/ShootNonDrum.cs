using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System.Collections;

public class ShootNonDrum : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _drumPos;
    [SerializeField] private StartGame _startGame;
    [SerializeField] private BulletNonDrum _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private ShootEffect _effect;
    [SerializeField] private LevelUpPrism _levelUpPrism;

    private float _currRotateX = 0f;
    private float _perRotate = 30f;
    private float _duractionRotate = 0.2f;

    private bool _canShoot = true;

    public int BulletsAmount { private get; set; }

    private void Shoot()
    {
        if (_canShoot)
        {
            BulletNonDrum bullet = Instantiate(_bullet);
            bullet.Initialize(_shootPoint.position);
            EffectInAnimator();

            _animator.SetTrigger("Shoot");
            _currRotateX -= _perRotate;
            _drumPos.DOLocalRotate(new Vector3(_drumPos.localEulerAngles.x, _drumPos.localEulerAngles.y, _currRotateX), _duractionRotate);
            BulletsAmount--;
            _canShoot = false;
        }
    }

    private IEnumerator StartShoot()
    {
        while(BulletsAmount > 0)
        {
            Shoot();
            yield return new WaitUntil(() => _canShoot == true);
        }

        if(_levelUpPrism.Hits > 0)
        {
            _startGame.OnContinuePlayer();
        }
    }

    public void OnStartShoot()
    {
        StartCoroutine(nameof(StartShoot));
    }

    public void ShootAnimEnd()
    {
        _canShoot = true;
    }

    private void EffectInAnimator()
    {
        _effect.Play();
    }

}
