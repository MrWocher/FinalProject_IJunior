using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private HitEffect _hitEffect;
    [SerializeField] private TrailRenderer _trailRenderer;

    private readonly MoveActions _moveAction = new MoveActions();

    private Vector3 _diraction;

    private bool _isActive = false;

    public float FireRange;

    public bool IsActive
    {
        get { return _isActive; }
        set { _isActive = value; }
    }

    public void Initialize(Vector3 pos, Vector3 rot, Vector3 diraction, float firerange)
    {
        transform.position = pos;
        transform.rotation = Quaternion.Euler(rot);
        _diraction = diraction;
        FireRange = firerange;

        gameObject.SetActive(true);
        StartCoroutine(nameof(ShootingTime));
    }

    private IEnumerator ShootingTime()
    {
        yield return new WaitForSeconds(FireRange);
        gameObject.SetActive(false);
        IsActive = false;
    }

    private void Update()
    {
        _moveAction.Move(gameObject.transform, _diraction, _speed);
    }

    public void StopShooting()
    {
        gameObject.SetActive(false);
        IsActive = false;
        StopCoroutine(nameof(ShootingTime));
    }

    public void Hit()
    {
        HitEffect hitEffect = Instantiate(_hitEffect);
        hitEffect.Initialize(transform.position, new Vector3(-90f, 0f, 0f));
    }

}
