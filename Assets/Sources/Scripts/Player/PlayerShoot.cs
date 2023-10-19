using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerShoot : ShootActionParams
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet[] _bullets;
    [SerializeField] private ShootEffect _effect;

    private readonly int ShootAnim = Animator.StringToHash("Shoot");

    private float _shootRate = 0.2f;
    private float _shootRange = 0.8f;

    private int _initBulletsAmount = 25;

    public float ShootRate
    {
        get
        {
            return _shootRate;
        }
        set
        {
            _shootRate = value;
        }
    }
    public float ShootRange
    {
        get
        {
            return _shootRange;
        }
        set
        {
            _shootRange = value;
        }
    }

    public int CurrentBullet { private get; set; }

    private void Awake()
    {
        CurrentBullet = 0;
        base.CreatePoolsObj(_bullets[CurrentBullet], _initBulletsAmount);
    }

    public void StartShoot()
    {
        StartCoroutine(nameof(Shooting));
    }

    public void StopShoot()
    {
        StopCoroutine(nameof(Shooting));
    }

    private IEnumerator Shooting()
    {
        var waitForSeconds = new WaitForSeconds(_shootRate);

        while (true)
        {
            _animator.SetTrigger(ShootAnim);

            yield return waitForSeconds;
        }
    }

    public override void Shoot(Transform shootPoint, Vector3 rot)
    {
        if(TryGetObject(out Bullet bullet))
        {
            bullet.Initialize(shootPoint.position, rot, Vector3.forward, _shootRange);
            bullet.IsActive = true;
        }
    }

    public void ShootInAnimator()
    {
        Shoot(_shootPoint, new Vector3(90f, 0f, 0f));
    }

    public void EffectInAnimator()
    {
        _effect.Play();
    }
}

