using UnityEngine;
using DG.Tweening;

public class LevelUP : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _arrowObj;
    [SerializeField] private StartGame _startGame;
    [SerializeField] private Vector3 _targetScale;

    private float _durcationScale = 1.2f;
    private float _jumpPower = 10f;
    private int _jumpsNum = 1;
    private float _duractionJump = 1f;

    public void Move()
    {
        _arrowObj.SetActive(true);
        _anim.enabled = false;

        transform.DOScale(_targetScale, _durcationScale);
        DOTween.Sequence()
            .Append(transform.DOLocalJump(_point.localPosition, _jumpPower, _jumpsNum, _duractionJump))
            .AppendCallback(_startGame.OnContinuePlayer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out UpgrateWeapon player))
        {
            player.Upgrate();
            gameObject.SetActive(false);
        }
    }
}
