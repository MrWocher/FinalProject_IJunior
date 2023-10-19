using UnityEngine;
using DG.Tweening;

public class DrumInWeapon : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private ShootNonDrum _shootNonDrum;

    private float _jumpPower = 1.2f;
    private int _jumpsNum = 1;
    private float _duraction = 1f;
    private float _duractionRotate = 0.4f;

    public int CurrentBullets { get; set; }

    private void OnEnable()
    {
        _shootNonDrum.BulletsAmount = CurrentBullets;

        DOTween.Sequence()
            .Append(transform.DOJump(_targetTransform.position, _jumpPower, _jumpsNum, _duraction))
            .Append(transform.DORotate(_targetTransform.localEulerAngles, _duractionRotate))
            .AppendCallback(SetParent)
            .AppendCallback(_shootNonDrum.OnStartShoot);
    }

    private void SetParent()
    {
        transform.SetParent(_targetTransform, true);
    }
}
